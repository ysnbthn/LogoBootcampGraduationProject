using BootcampProject.Core.DTOs;
using BootcampProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IUserService
    {
        List<GetUserDto> GetPagedUsers(int page);
        GetUserDto GetUserById(string id);
        ResponseDto AddUser(CreateUserDto entity);
        ResponseDto UpdateUser(UpdateUserDto entity);
        ResponseDto DeleteUser(ApplicationUser entity);
    }
}
