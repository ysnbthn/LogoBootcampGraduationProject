namespace BootcampProject.Core.DTOs.UserPaymentDtos
{
    public class BillDto //viewden gelen
    {
        public string CreditCardNumber { get; set; }
        public string Email { get; set; }
        public double Amount { get; set; }
        public int InvoiceId { get; set; }
    }
}
