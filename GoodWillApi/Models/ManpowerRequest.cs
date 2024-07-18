namespace GoodWillApi.Models;

public class ManpowerRequest
{
    public Guid Id { get; set; }
    public required string PlaceName { get; set; }
    public int VolunteerCount { get; set; }
    public required string IncidentType { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required User User { get; set; }
    public Guid UserId { get; set; }
}
