using AutoMapper;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Mapper
{
    public class ServiceCarProfile : Profile
    {
        public ServiceCarProfile()
        {
            CreateMap<Part, PartDTO>().ReverseMap();
        }
    }
}