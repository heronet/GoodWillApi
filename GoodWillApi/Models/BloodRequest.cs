namespace GoodWillApi.Models;

public class BloodRequest
{
    public Guid Id { get; set; }
    public required string PatientName { get; set; }
    public required string PlaceName { get; set; }
    public required string Phone { get; set; }
    public required string BloodGroup { get; set; }
    public int BagCount { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required User User { get; set; }
    public Guid UserId { get; set; }
}
