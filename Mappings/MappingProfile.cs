using AutoMapper;
using Caravan.Entities;
using Caravan.Models;

namespace Caravan.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, Customer>();
        }
    }
}