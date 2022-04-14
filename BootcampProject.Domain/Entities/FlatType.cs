using System;

namespace BootcampProject.Domain.Entities
{
    public class FlatType : BaseEntity
    {
        public string Name { get; set; }

        public Guid Id { get => Id; set => Guid.NewGuid().ToString(); }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}