using System.Collections.Generic;

namespace BootcampProject.Core.DTOs
{
    public class UserActionDto
    {
        public List<GetUserDto> Users = new List<GetUserDto>();
        public UpdateUserDto EditUser { get; set; }
        public CreateUserDto CreateUser { get; set; }
        public object Result { get; set; }
    }
}
