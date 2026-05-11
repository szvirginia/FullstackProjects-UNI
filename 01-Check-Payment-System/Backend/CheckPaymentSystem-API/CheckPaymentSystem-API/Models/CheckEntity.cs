namespace CheckPaymentSystem_API.Models
{
    public enum PaymentType
    {
        Utilities, Penalty, Tax, Other
    }
    public class CheckEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Paid { get; set; }
        public DateTime Date { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsProcessed { get; set; }
    }
}
