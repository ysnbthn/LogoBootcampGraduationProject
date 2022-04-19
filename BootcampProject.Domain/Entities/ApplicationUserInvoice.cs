namespace BootcampProject.Domain.Entities
{
    public class ApplicationUserInvoice
    {
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
