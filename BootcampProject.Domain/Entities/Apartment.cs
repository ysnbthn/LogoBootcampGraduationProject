using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        public bool Occupied { get; set; }       
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public Guid FlatTypeId { get; set; }
        public FlatType FlatType { get; set; }

        public Guid BlockId { get; set; }
        public Block Block { get; set; }

        public Guid? OwnerOrHirerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public Guid Id { get => Id; set => Guid.NewGuid().ToString(); }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
