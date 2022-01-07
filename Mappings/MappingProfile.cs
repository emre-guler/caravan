using AutoMapper;
using Caravan.Entities;
using Caravan.Models;

namespace Caravan.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Register, Customer>();
            CreateMap<ApiData, Customer>();
        }
    }
}