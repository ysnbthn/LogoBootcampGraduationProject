using BootcampProject.Core.DTOs;
using BootcampProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampProject.Core.Abstract
{
    public interface IUserService
    {
        List<ApplicationUser> GetPagedUsersAsync(int page);
        ApplicationUser GetUserById(string id);
        ResponseDto AddUser(ApplicationUser entity);
        ResponseDto UpdateUser(ApplicationUser entity);
        ResponseDto DeleteUser(ApplicationUser entity);
    }
}
