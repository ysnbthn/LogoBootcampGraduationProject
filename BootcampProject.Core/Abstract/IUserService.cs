using BootcampProject.Core.DTOs;

namespace BootcampProject.Core.Abstract
{
    public interface IUserService
    {
        PaginatedUsersDto GetPagedUsers(int page);
        UpdateUserDto GetUserById(int id);
        ResponseDto AddUser(CreateUserDto entity);
        ResponseDto UpdateUser(UpdateUserDto entity);
        ResponseDto DeleteUser(int entityId);
    }
}
