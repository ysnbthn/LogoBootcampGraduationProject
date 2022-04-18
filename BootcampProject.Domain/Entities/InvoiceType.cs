using System;

namespace BootcampProject.Domain.Entities
{
    public class InvoiceType : BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public string Name { get; set; }

    }
}