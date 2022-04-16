using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.Core.Concretes
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ApartmentService(IRepository<Apartment> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseDto AddApartment(CreateApartmentDto entity)
        {
            var apartmentExists = _repository.Get().Any(x => x.ApartmentNumber == entity.ApartmentNumber);

            if (apartmentExists) return new ResponseDto { Error = "Apartment already exists", Success = false };

            Apartment apart = new Apartment
            {
                Occupied = entity.OwnerOrHirerId.ToString() == null ? true : false,
                Floor = entity.Floor,
                ApartmentNumber = entity.ApartmentNumber,
                FlatTypeId = entity.FlatTypeId,
                OwnerOrHirerId = entity.OwnerOrHirerId.ToString() == "" ? null : entity.OwnerOrHirerId,
                BlockId = entity.BlockId,
                IsDeleted = false
            };

            _repository.Add(apart);

            //entity.Occupied = entity.OwnerOrHirerId.ToString() != "" || entity.OwnerOrHirerId.ToString() != null ? true : false;
            //_repository.Add(_mapper.Map<Apartment>(entity));
            _unitOfWork.Commit();
            
            return new ResponseDto { Success = true, Data = "Apartment created successfully" };
        }

        public List<BlockDto> GetBlocks()
        {
            var blockList = _unitOfWork.Context.Blocks.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<List<BlockDto>>(blockList);
        }

        public List<FlatTypeDto> GetFlatTypes()
        {
            var flatTypeList = _unitOfWork.Context.FlatTypes.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<List<FlatTypeDto>>(flatTypeList);
        }

        public PaginatedApartmentsDto GetPagedApartments(int page = 1)
        {
            int totalApartments = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalApartments / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalApartments / 10.0));

            var apartments = _repository.Get()
                .Include(x => x.Block)
                .Include(x => x.FlatType)
                .Include(x => x.ApplicationUser)
                .OrderByDescending(x => x.CreatedAt)
                .Skip(((page >= max ? max : page) - 1) * 10)
                .Take(10)
                .ToList();
            
            return new PaginatedApartmentsDto { Apartments = _mapper.Map<List<GetApartmentDto>>(apartments), TotalPages = max, CurrentPage = page };
        }

        public List<ResidentsDto> GetResidents()
        {
            var residents = _unitOfWork.Context.Users.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<List<ResidentsDto>>(residents);
        }
    }
}
