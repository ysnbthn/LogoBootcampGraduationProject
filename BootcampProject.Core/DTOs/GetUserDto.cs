using System;

namespace BootcampProject.Core.DTOs
{
    public class GetUserDto
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlateNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
