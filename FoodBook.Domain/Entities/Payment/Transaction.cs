public class Transaction
{
    public int Id { get; set; }
    public int PaymentId { get; set; }
    public Payment Payment { get; set; }
    public string TransactionId { get; set; }
    public string Status { get; set; }
    public DateTime ProcessedAt { get; set; }
}