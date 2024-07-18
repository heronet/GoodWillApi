using System.Security.Claims;
using GoodWillApi.Data;
using GoodWillApi.Data.DTO;
using GoodWillApi.Extensions;
using GoodWillApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWillApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ManpowerController(GoodDbContext dbContext) : ControllerBase
{
    private readonly GoodDbContext _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult> GetRequests()
    {
        var requests = await _dbContext.ManpowerRequests
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        return Ok(requests);
    }


    [HttpPost("request")]
    public async Task<ActionResult> AddRequest([FromBody] ManpowerRequestDto manpowerRequestDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));

        if (user is null) return NotFound();

        var manpowerRequest = new ManpowerRequest
        {
            PlaceName = manpowerRequestDto.PlaceName,
            VolunteerCount = manpowerRequestDto.VolunteerCount,
            IncidentType = manpowerRequestDto.IncidentType,
            Lat = manpowerRequestDto.Lat,
            Lng = manpowerRequestDto.Lng,
            User = user
        };

        _dbContext.ManpowerRequests.Add(manpowerRequest);

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequests), manpowerRequest.ToManpowerRequestDto());
    }

    [HttpPost("volunteer")]
    public async Task<ActionResult> AddDonation([FromBody] BloodDonationDto bloodDonationDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));

        if (user is null) return NotFound();

        var request = await _dbContext.BloodRequests.FirstOrDefaultAsync(d => d.Id == bloodDonationDto.BloodRequestId);

        if (request is null) return NotFound();

        var bloodDonation = new BloodDonation
        {

            BagCount = bloodDonationDto.BagCount,
            BloodRequest = request,
            User = user
        };

        _dbContext.BloodDonations.Add(bloodDonation);

        // Update the request object
        request.BagCount -= bloodDonationDto.BagCount;

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequests), bloodDonation.ToBloodDonationDto());
    }
}
