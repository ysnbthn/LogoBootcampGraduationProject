namespace BootcampProject.Core.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlateNumber { get; set; }
    }
}
