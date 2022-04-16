using AutoMapper;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.Domain.Entities;
using System;

namespace BootcampProject.Core.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, CreateUserDto>().ReverseMap();
            CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();

            CreateMap<Apartment, GetApartmentDto>()
                .ForMember(d => d.BlockName, o => o.MapFrom(s => s.Block.Name))
                .ForMember(d => d.FlatTypeName, o => o.MapFrom(s => s.FlatType.Name))
                .ForMember(d => d.OwnerId, o => o.MapFrom(s => s.OwnerOrHirerId))
                .ForMember(d => d.OwnerFullName, o => o.MapFrom(s => s.ApplicationUser.Name + " " + s.ApplicationUser.Surname))
                //.ForMember(d => d.Occupied, o => o.MapFrom(s => s.ApplicationUser.Id != null ? true: false))
                .ForMember(d => d.OwnerEmail, o => o.MapFrom(s => s.ApplicationUser.Email));

            CreateMap<CreateApartmentDto, Apartment>();
                //.ForMember(d => d.BlockId, o => o.MapFrom(s => new Guid(s.BlockId)))
                //.ForMember(d => d.FlatTypeId, o => o.MapFrom(s => new Guid(s.FlatTypeId)))
                //.ForMember(d => d.OwnerOrHirerId, o => o.MapFrom(s => new Guid(s.OwnerOrHirerId)))
                //.ForMember(d => d.ApartmentNumber, o => o.MapFrom(s => s.ApartmentNumber))
                //.ForMember(d => d.Occupied, o => o.MapFrom(s => s.Occupied));



            CreateMap<Block, BlockDto>().ReverseMap();
            CreateMap<FlatType, FlatTypeDto>().ReverseMap();
            CreateMap<ApplicationUser, ResidentsDto>().ReverseMap();
            
        }
    }
}
