namespace GoodWillApi.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string BloodGroup { get; set; } = string.Empty;
    public string PlaceName { get; set; } = string.Empty;
    public double Lat { get; set; }
    public double Lng { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<BloodRequest> BloodRequests { get; set; } = [];
}
