using System;

namespace BootcampProject.Domain.Entities
{
    public class Block : BaseEntity
    {
        public string Name { get; set; }
        
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}