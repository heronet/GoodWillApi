namespace GoodWillApi.Data.DTO;

public class BloodDonationDto
{
    public Guid Id { get; set; }
    public int BagCount { get; set; }
    public Guid BloodRequestId { get; set; }
    public Guid UserId { get; set; }
}
