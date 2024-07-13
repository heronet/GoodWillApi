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
}
