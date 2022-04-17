using System;
namespace BootcampProject.Core.DTOs.ApartmentDtos
{
    public class GetApartmentDto
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        
        public string FlatTypeName { get; set; }
        public string BlockName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerEmail { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
