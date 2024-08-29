using GoodWillApi.Models;

namespace GoodWillApi.Data.DTO;

public class ManpowerDonationDto
{
    public Guid Id { get; set; }
    public int VolunteerCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid ManpowerRequestId { get; set; }
    public Guid UserId { get; set; }
}
