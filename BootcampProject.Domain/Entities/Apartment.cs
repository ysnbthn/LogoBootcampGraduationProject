using System;

namespace BootcampProject.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        public bool Occupied { get; set; }       
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public int FlatTypeId { get; set; }
        public FlatType FlatType { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }

        public int? OwnerOrHirerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
