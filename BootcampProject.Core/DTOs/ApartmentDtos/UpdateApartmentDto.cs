namespace BootcampProject.Core.DTOs.ApartmentDtos
{
    public class UpdateApartmentDto
    {
        public int Id { get; set; }
        public bool Occupied { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }

        public int FlatTypeId { get; set; }
        public int BlockId { get; set; }
        public int OwnerOrHirerId { get; set; }
    }
}
