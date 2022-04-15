using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BootcampProject.Core.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(IRepository<ApplicationUser> repository, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public ResponseDto AddUser(CreateUserDto entity)
        {
            var userTCNoExists = _unitOfWork.Context.Users.Any(x => x.TCNo == entity.TCNo);

            if (userTCNoExists) return new ResponseDto { Success = false, Error = "There is already a member in database with same TC number" };

            var userMailExists = _unitOfWork.Context.Users.Any(x => x.Email == entity.Email);

            if (userMailExists) return new ResponseDto { Success = false, Error = "There is already a member in database with same email" };

            _repository.Add(_mapper.Map<ApplicationUser>(entity));
            _unitOfWork.Commit();

            return new ResponseDto { Success = true, Data = "User added successfully" };
        }


        public ResponseDto DeleteUser(ApplicationUser entity)
        {
            var user = _repository.GetById(entity.Id);

            if(user == null) return new ResponseDto { Success = false, Error = "User is not exists!" };

            _repository.Delete(entity);
            _unitOfWork.Commit();
            
            return new ResponseDto { Success = true, Data = "User deleted successfully" };
        }

        public List<GetUserDto> GetPagedUsers(int page)
        {
            int totalUsers = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalUsers / 10.0));

            var users = _repository.Get().Skip((page >= max ? max : page) - 1).Take(10).OrderBy(x => x.CreatedAt).ToList();

            List<ApplicationUser> filteredUsers = new List<ApplicationUser>();

            users.ForEach(x =>
            {
                if (!_userManager.IsInRoleAsync(x, "Admin").Result)
                {
                    filteredUsers.Add(x);
                }
            });

            return _mapper.Map<List<GetUserDto>>(filteredUsers);
        }

        public GetUserDto GetUserById(string id)
        {
            var user = _repository.GetById(id);

            return user != null ? _mapper.Map<GetUserDto>(user) : null;
        }

        public ResponseDto UpdateUser(UpdateUserDto entity)
        {
            var user = _repository.GetById(entity.Id);

            if (user == null) return new ResponseDto { Success = false, Error = "User is not exists!" };

            _repository.Update(_mapper.Map<ApplicationUser>(entity));
            _unitOfWork.Commit();

            return new ResponseDto { Success = true, Data = "User updated successfully" };
        }
    }


}

