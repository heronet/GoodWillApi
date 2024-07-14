namespace GoodWillApi.Models;

public class BloodDonation
{
    public Guid Id { get; set; }
    public int BagCount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required BloodRequest BloodRequest { get; set; }
    public Guid BloodRequestId { get; set; }
    public required User User { get; set; }
    public Guid UserId { get; set; }
}
