using System;

namespace BootcampProject.Domain.Entities
{
    public class Apartment : BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public bool Occupied { get; set; }

        public int FlatTypeId { get; set; }
        public FlatType FlatType { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
