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

        public int FlatTypeId { get; set; }
        public FlatType FlatType { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }

        public int OwnerOrHirerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
