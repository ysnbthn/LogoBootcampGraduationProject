namespace BootcampProject.Domain.Entities
{
    public class ApplicationUserInvoices
    {
        public int UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
