using System;

namespace BootcampProject.Core.DTOs.ApartmentDtos
{
    public class CreateApartmentDto
    {
        public bool Occupied { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public Guid FlatTypeId { get; set; }
        public Guid BlockId { get; set; }
        public Guid OwnerOrHirerId { get; set; }
    }
}
