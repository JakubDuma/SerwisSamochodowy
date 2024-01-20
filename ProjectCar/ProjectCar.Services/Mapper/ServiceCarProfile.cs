using AutoMapper;
using ProjectCar.Data.Models;
using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Mappers
{
    public class ServiceCarProfile : Profile
    {
        public ServiceCarProfile()
        {
            CreateMap<Part, PartDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Timetable, TimetableDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
        }
    }
}