using AutoMapper;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.DataAccess.EntityFramework;
using BootcampProject.Domain.Entities;
using System;

namespace BootcampProject.Core.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        private readonly ApplicationDbContext context;

        public MappingProfiles(ApplicationDbContext context)
        {
            this.context = context;
        }

        public MappingProfiles()
        {
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();

            CreateMap<Apartment, GetApartmentDto>()
                .ForMember(d => d.BlockName, o => o.MapFrom(s => s.Block.Name))
                .ForMember(d => d.FlatTypeName, o => o.MapFrom(s => s.FlatType.Name))
                .ForMember(d => d.OwnerId, o => o.MapFrom(s => s.ApplicationUserId != 0 ? s.ApplicationUserId : 0))
                .ForMember(d => d.OwnerFullName, o => o.MapFrom(s => s.ApplicationUser.Name + " " + s.ApplicationUser.Surname)) //s.ApplicationUser != null ? s.ApplicationUser.Name + " " + s.ApplicationUser.Surname : ""
                .ForMember(d => d.OwnerEmail, o => o.MapFrom(s => s.ApplicationUser.Email));

            CreateMap<CreateApartmentDto, Apartment>()
                .ForMember(x => x.ApplicationUserId, o => o.MapFrom(s => s.OwnerOrHirerId));
                //.ForMember(x=>x.ApplicationUser, o=>o.MapFrom(s=> context.Users.Find(s.OwnerOrHirerId)));


            CreateMap<Block, BlockDto>().ReverseMap();
            CreateMap<FlatType, FlatTypeDto>().ReverseMap();
            CreateMap<ApplicationUser, ResidentsDto>()
                .ForMember(x=>x.OwnerOrHirerId, o=>o.MapFrom(s=>s.Id));
            CreateMap<ResidentsDto, ApplicationUser>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.OwnerOrHirerId));
            
        }
    }
}
