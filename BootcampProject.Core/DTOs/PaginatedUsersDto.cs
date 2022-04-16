using System.Collections.Generic;

namespace BootcampProject.Core.DTOs
{
    public class PaginatedUsersDto
    {
        public List<GetUserDto> Users { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
