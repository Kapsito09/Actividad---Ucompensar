using AutoMapper;
using DataAccess.Models;
using DTO;

namespace Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}