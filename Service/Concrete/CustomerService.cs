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
        public CustomerService(
            IMapper mapper,
            CaravanContext db
        )
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<List<ErrorModel>> Login(Login loginData)
        {
            List<ErrorModel> modelErrors = new List<ErrorModel>();
            var customerControl = await _db.Customers.FirstOrDefaultAsync(x => x.MailAddress == loginData.MailAddress && !x.DeletedAt.HasValue);
            if(customerControl is not null)
            {
                if(BCrypt.Net.BCrypt.Verify(loginData.Password, customerControl.Password))
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
                customerData.Password = BCrypt.Net.BCrypt.HashPassword(customerData.Password);
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
    }
}