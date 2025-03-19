namespace Hmw17;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public DateTime Timestamp { get; set; }
    public string Description { get; set; }
    public string Merchant { get; set; }
}
