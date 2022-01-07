using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Caravan.Data;
using Caravan.Entities;
using Caravan.Interfaces;
using Caravan.Models;
using Microsoft.EntityFrameworkCore;

namespace Caravan.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly CaravanContext _db;
        private readonly IMailService _mailService;
        private readonly IRedisService _redisService;
        public CustomerService(
            IMapper mapper,
            CaravanContext db,
            IMailService mailService,
            IRedisService redisService
        )
        {
            _mapper = mapper;
            _db = db;
            _mailService = mailService;
            _redisService = redisService;
        }

        public async Task<List<ErrorModel>> Login(Login loginData)
        {
            List<ErrorModel> modelErrors = new List<ErrorModel>();
            var customerControl = await _db.Customers.FirstOrDefaultAsync(x => x.MailAddress == loginData.MailAddress && !x.DeletedAt.HasValue);
            if(customerControl is not null)
            {
                if(loginData.Password == customerControl.Password)
                {
                    return modelErrors;
                }
            }
            modelErrors.Add(new ErrorModel 
            {
                Title = "InvalidCredentials",
                Message = "Mail adresi veya şifre hatalı, tekrar deneyin."
            });
            return modelErrors;
        }

        public async Task<List<ErrorModel>> Register(Register registerData)
        {
            List<ErrorModel> modelErrors = new List<ErrorModel>();
            var mailControl = await _db.Customers.FirstOrDefaultAsync(x => x.MailAddress == registerData.MailAddress  && x.PhoneNumber == registerData.PhoneNumber && !x.DeletedAt.HasValue);
            if(mailControl is null)
            {
                var customerData = _mapper.Map<Customer>(registerData);

                customerData.Password = customerData.Password;
                customerData.CreatedAt = System.DateTime.UtcNow;
                await _db.AddAsync(customerData);
                await _db.SaveChangesAsync();
                return modelErrors;
            }
            modelErrors.Add(new ErrorModel 
            {
                Title = "EMailAlreadyInUse",
                Message = "Bu mail veya numara zaten kayıtlı."
            });
            return modelErrors;
        }

        public async Task<ApiData> GetApiData(Customer currentCustomer)
        {
            var userData = await _db.Customers.FirstOrDefaultAsync(x => x.Id == currentCustomer.Id);
            return _mapper.Map<ApiData>(userData);
        } 
        
        public async Task<List<ErrorModel>> SetApiData(ApiData apiData, Customer currentCustomer)
        {
            List<ErrorModel> modelErrors = new();
            var userData = await _db.Customers.FirstOrDefaultAsync(x => x.Id == currentCustomer.Id);
            if(userData != null)
            {
                userData.SellerId = apiData.SellerId;
                userData.ApiKey = apiData.ApiKey;
                userData.ApiSecret = apiData.ApiSecret;
                await _db.SaveChangesAsync();
                await _redisService.Add($"logs-{currentCustomer.Id}-{DateTime.UtcNow}", "Api data has been changed!");
                return modelErrors;
            }
            modelErrors.Add(new ErrorModel 
            {
                Title = "NotFound",
                Message = "Kullanıcı bulunamadı tekrar deneyin."
            });
            return modelErrors;
        }

        public async Task<Customer> GetCustomerByMailAddress(string mailAddress)
        {
            return await _db.Customers.FirstOrDefaultAsync(x => x.MailAddress == mailAddress && !x.DeletedAt.HasValue);
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await _db.Customers.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ErrorModel>> ChangePassword(ChangePassword passwordData, Customer currentCustomer)
        {
            List<ErrorModel> modelErrors = new();
            if(currentCustomer.Password == passwordData.OldPassword)
            {
                currentCustomer.Password = passwordData.NewPassword;
                await _db.SaveChangesAsync();
                EmailConfiguration passwordMail = new();
                passwordMail.To = currentCustomer.MailAddress;
                passwordMail.Subject = "Şifreniz Yenilendi";
                passwordMail.Body = "Şifreniz değiştirilmiştir!";
                _mailService.SendMail(passwordMail);
                await _redisService.Add($"logs-{currentCustomer.Id}-{DateTime.UtcNow}", "Password has been changed!");
                return modelErrors; 
            }
            modelErrors.Add(new ErrorModel 
            {
                Title = "InvalidCredential",
                Message = "Eski parola hatalı."
            });
            return modelErrors;
        }
    }
}