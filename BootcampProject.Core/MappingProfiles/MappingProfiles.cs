using AutoMapper;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.Core.DTOs.InvoiceDtos;
using BootcampProject.Core.DTOs.PaymnetDtos;
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
                .ForMember(d => d.ApplicationUserId, o => o.MapFrom(s => s.OwnerOrHirerId));
            CreateMap<UpdateApartmentDto, Apartment>()
                .ForMember(d => d.ApplicationUserId, o => o.MapFrom(s => s.OwnerOrHirerId)).ReverseMap();


            CreateMap<Block, BlockDto>().ReverseMap();
            CreateMap<FlatType, FlatTypeDto>().ReverseMap();
            CreateMap<ApplicationUser, ResidentsDto>()
                .ForMember(d => d.OwnerOrHirerId, o => o.MapFrom(s => s.Id));
            CreateMap<ResidentsDto, ApplicationUser>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.OwnerOrHirerId));
            
            CreateMap<ApplicationUser, UsersForPaymentDto>();
            CreateMap<CreatePaymentDto, Payment>();//test
                //.ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount))
                //.ForMember(d => d.BillingDate, o => o.MapFrom(s => s.BillingDate))
                //.ForMember(d => d.PaymentDue, o => o.MapFrom(s => s.PaymentDue))
                //.ForMember(d => d.PaymentType, o => o.MapFrom(s => s.PaymentType))
                //.ForMember(d => d.UserName, o => o.MapFrom(s => s.UserName))
                //.ForMember(d => d.UserEmail, o=>o.MapFrom(s=>s.UserEmail))
                //.ForMember(d=>d.);

            CreateMap<Invoice, CreatePaymentDto>()
                .ForMember(d => d.PaymentType, o => o.MapFrom(s => s.InvoiceType.Name))
                .ForMember(d => d.Amount, o => o.MapFrom(s => s.Amount.ToString()))
                .ForMember(d => d.PaymentDue, o => o.MapFrom(s => s.PaymentDue));

            CreateMap<Invoice, GetInvoiceDto>()
                .ForMember(d => d.InvoiceTypeName, o => o.MapFrom(s => s.InvoiceType.Name));

            CreateMap<InvoiceType, InvoiceTypeDto>().ReverseMap();
            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(d => d.Amount, o => o.MapFrom(s => decimal.Parse(s.Amount)))
                .ReverseMap();
            CreateMap<UpdateInvoiceDto, Invoice>()
                .ForMember(d => d.Amount, o => o.MapFrom(s => decimal.Parse(s.Amount)))
                .ReverseMap();
        }
    }
}
