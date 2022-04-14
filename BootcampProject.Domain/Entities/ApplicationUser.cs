using Microsoft.AspNetCore.Identity;
using System;

namespace BootcampProject.Domain.Entities
{
    public class ApplicationUser : IdentityUser, BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string CarPlateNumber { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        Guid BaseEntity.Id { get => new Guid(this.Id); set => this.Id = Guid.NewGuid().ToString(); }
    }
}
 