using System.ComponentModel.DataAnnotations;

namespace GoodWillApi.Data.DTO;

public class BloodRequestDto
{
    public Guid Id { get; set; }

    [Required]
    public string PatientName { get; set; } = string.Empty;

    [Required]
    public string PlaceName { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public string BloodGroup { get; set; } = string.Empty;

    [Required]
    public int BagCount { get; set; }

    [Required]
    public double Lat { get; set; }

    [Required]
    public double Lng { get; set; }
    public Guid UserId { get; set; }


}
