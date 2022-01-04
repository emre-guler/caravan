using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Caravan.Data;
using Caravan.Entities;
using Caravan.Interfaces;
using Caravan.Models;

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

        public async Task<List<ErrorModel>> Register(Register registerData)
        {
            List<ErrorModel> modelErrors = new List<ErrorModel>();
            var mailControl = _db.Customers.FirstOrDefault(x => x.MailAddress == registerData.MailAddress  && x.PhoneNumber == registerData.PhoneNumber , null);
            if(mailControl != null)
            {
                var customerData = _mapper.Map<Customer>(registerData);
                customerData.Password = BCrypt.Net.BCrypt.HashPassword(customerData.Password);
                await _db.AddAsync(customerData);
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