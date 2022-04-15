using AutoMapper;
using BootcampProject.Core.DTOs;
using BootcampProject.Domain.Entities;

namespace BootcampProject.Core.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
        }
    }
}
