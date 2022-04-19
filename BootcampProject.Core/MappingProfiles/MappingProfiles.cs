using AutoMapper;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.Core.DTOs.InvoiceDtos;
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
                .ForMember(d => d.OwnerId, o => o.MapFrom(s => s.ApplicationUserId))
                .ForMember(d => d.OwnerEmail, o => o.MapFrom(s => s.ApplicationUser.Email));
            CreateMap<CreateApartmentDto, Apartment>()
                .ForMember(x => x.ApplicationUserId, o => o.MapFrom(s => s.OwnerOrHirerId));
            CreateMap<UpdateApartmentDto, Apartment>()
                .ForMember(x => x.ApplicationUserId, o => o.MapFrom(s => s.OwnerOrHirerId)).ReverseMap();


            CreateMap<Block, BlockDto>().ReverseMap();
            CreateMap<FlatType, FlatTypeDto>().ReverseMap();
            CreateMap<ApplicationUser, ResidentsDto>()
                .ForMember(x => x.OwnerOrHirerId, o => o.MapFrom(s => s.Id));
            CreateMap<ResidentsDto, ApplicationUser>()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.OwnerOrHirerId));

            CreateMap<Invoice, GetInvoiceDto>()
                .ForMember(i => i.InvoiceTypeName, o => o.MapFrom(s => s.InvoiceType.Name));

            CreateMap<InvoiceType, InvoiceTypeDto>().ReverseMap();
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(i => i.Amount, o => o.MapFrom(s => decimal.Parse(s.Amount)))
                .ReverseMap();
            CreateMap<UpdateInvoiceDto, Invoice>()
                .ForMember(i => i.Amount, o => o.MapFrom(s => decimal.Parse(s.Amount)))
                .ReverseMap();
        }
    }
}
