using GoodWillApi.Data.DTO;
using GoodWillApi.Models;

namespace GoodWillApi.Extensions;

public static class DtoConverter
{
    public static BloodRequestDto ToBloodRequestDto(this BloodRequest bloodRequest)
    {
        return new BloodRequestDto
        {
            Id = bloodRequest.Id,
            PatientName = bloodRequest.PatientName,
            PlaceName = bloodRequest.PlaceName,
            BagCount = bloodRequest.BagCount,
            BloodGroup = bloodRequest.BloodGroup,
            Lat = bloodRequest.Lat,
            Lng = bloodRequest.Lng,
            UserId = bloodRequest.UserId,
        };
    }
    public static BloodDonationDto ToBloodDonationDto(this BloodDonation bloodDonation)
    {
        return new BloodDonationDto
        {
            Id = bloodDonation.Id,
            BagCount = bloodDonation.BagCount,
            BloodRequestId = bloodDonation.BloodRequestId,
            UserId = bloodDonation.UserId,
        };
    }

    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            PlaceName = user.PlaceName,
            Phone = user.Phone,
            Email = user.Email,
            BloodGroup = user.BloodGroup,
            Lat = user.Lat,
            Lng = user.Lng,
            CreatedAt = user.CreatedAt,
        };
    }
    public static ManpowerRequestDto ToManpowerRequestDto(this ManpowerRequest manpowerRequest)
    {
        return new ManpowerRequestDto
        {
            Id = manpowerRequest.Id,
            PlaceName = manpowerRequest.PlaceName,
            VolunteerCount = manpowerRequest.VolunteerCount,
            Lat = manpowerRequest.Lat,
            Lng = manpowerRequest.Lng,
            UserId = manpowerRequest.UserId,
        };
    }
    public static ManpowerDonationDto ToManpowerDonationDto(this ManpowerDonation manpowerDonation)
    {
        return new ManpowerDonationDto
        {
            Id = manpowerDonation.Id,
            VolunteerCount = manpowerDonation.VolunteerCount,
            ManpowerRequestId = manpowerDonation.ManpowerRequestId,
            UserId = manpowerDonation.UserId,
        };
    }
}
