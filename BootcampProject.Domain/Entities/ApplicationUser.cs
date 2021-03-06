using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BootcampProject.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>, BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNo { get; set; }
        public string CarPlateNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public IList<ApplicationUserInvoice> ApplicationUserInvoices { get; set; }
    }
}
 