using BootcampProject.Core.DTOs;
using BootcampProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IUserService
    {
        PaginatedUsersDto GetPagedUsers(int page);
        UpdateUserDto GetUserById(string id);
        ResponseDto AddUser(CreateUserDto entity);
        ResponseDto UpdateUser(UpdateUserDto entity);
        ResponseDto DeleteUser(string entityId);
    }
}
