using System.ComponentModel.DataAnnotations;

namespace GoodWillApi.Data.DTO;

public class ManpowerRequestDto
{
    public Guid Id { get; set; }

    [Required]
    public string PlaceName { get; set; } = string.Empty;
    [Required]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public string IncidentType { get; set; } = string.Empty;

    [Required]
    public int VolunteerCount { get; set; }

    [Required]
    public double Lat { get; set; }

    [Required]
    public double Lng { get; set; }
    public Guid UserId { get; set; }


}
