using AutoMapper;
using BootcampProject.Core.Abstract;
using BootcampProject.Core.DTOs;
using BootcampProject.DataAccess.EntityFramework.Repository.Abstracts;
using BootcampProject.Domain.Entities;
using BootcampProject.Domain.MongoDbEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

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

            var user = _mapper.Map<ApplicationUser>(entity);

            user.EmailConfirmed = true;
            user.CreatedAt = DateTime.Now;
            user.UserName = entity.Email;

            _userManager.CreateAsync(user, entity.Password).Wait();
            _userManager.AddToRoleAsync(user, "Basic").Wait();

            HttpClient client = new HttpClient();
            var url = new Uri("https://localhost:44355/api/CreditCardPayment/NewUser");

            var userToAddToApi = new User
            {
                Email = entity.Email,
                Password = entity.Password,
                CreditCards = new CreditCard[] { },
            };

            var serilizedObject = Newtonsoft.Json.JsonConvert.SerializeObject(userToAddToApi);
            var requestContent = new StringContent(serilizedObject, Encoding.UTF8, "application/json");

            var response = client.PostAsync(url, requestContent).Result;
            response.EnsureSuccessStatusCode();

            return new ResponseDto { Success = true, Data = "User added successfully" };
        }

        
        public ResponseDto DeleteUser(int id)
        {
            var user = _repository.GetById(new ApplicationUser { Id = id }.Id);

            if(user == null) return new ResponseDto { Success = false, Error = "User is not exists!" };

            _repository.Delete(user);
            _unitOfWork.Commit();
            
            return new ResponseDto { Success = true, Data = "User deleted successfully" };
        }

        public PaginatedUsersDto GetPagedUsers(int page)
        {
            int totalUsers = _repository.Get().Count();
            int max = Convert.ToInt32(Math.Ceiling(totalUsers / 10.0)) == 0 ? 1 : Convert.ToInt32(Math.Ceiling(totalUsers / 10.0));

            var users = _repository.Get().OrderByDescending(x => x.CreatedAt).Skip(((page >= max ? max : page) - 1)*10).Take(10).ToList();

            List<ApplicationUser> filteredUsers = new List<ApplicationUser>();

            users.ForEach(x =>
            {
                if (!_userManager.IsInRoleAsync(x, "Admin").Result)
                {
                    filteredUsers.Add(x);
                }
            });

            return new PaginatedUsersDto { Users = _mapper.Map<List<GetUserDto>>(filteredUsers), TotalPages = max, CurrentPage = page };
        }

        public UpdateUserDto GetUserById(int id)
        {
            var user = _repository.GetById(id);

            return _mapper.Map<UpdateUserDto>(user);
        }

        public ResponseDto UpdateUser(UpdateUserDto entity)
        {
            var user = _repository.GetById(entity.Id);

            if (user == null) return new ResponseDto { Success = false, Error = "User is not exists!" };

            var userTCNoExists = _unitOfWork.Context.Users.Any(x => x.TCNo == entity.TCNo && x.Id != entity.Id);

            if (userTCNoExists) return new ResponseDto { Success = false, Error = "There is already a member in database with same TC number" };

            _mapper.Map(entity, user);
            //_userManager.UpdateAsync(user).Wait();

            _repository.Update(_mapper.Map<ApplicationUser>(user));
            _unitOfWork.Commit();

            return new ResponseDto { Success = true, Data = "User updated successfully" };
        }
    }


}

