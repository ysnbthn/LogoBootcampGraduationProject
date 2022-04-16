using System;

namespace BootcampProject.Core.DTOs.ApartmentDtos
{
    public class ResidentsDto
    {
        public Guid OwnerOrHirerId { get; set; }
        public string Email { get; set; }
    }
}
