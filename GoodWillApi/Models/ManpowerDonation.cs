namespace GoodWillApi.Models;

public class ManpowerDonation
{
    public Guid Id { get; set; }
    public int VolunteerCount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required ManpowerRequest ManpowerRequest { get; set; }
    public Guid ManpowerRequestId { get; set; }
    public required User User { get; set; }
    public Guid UserId { get; set; }
}
