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
            .Where(r => r.VolunteerCount > 0)
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
            Phone = manpowerRequestDto.Phone,
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
    public async Task<ActionResult> AddDonation([FromBody] ManpowerDonationDto manpowerDonationDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));

        if (user is null) return NotFound();

        var request = await _dbContext.ManpowerRequests.FirstOrDefaultAsync(d => d.Id == manpowerDonationDto.ManpowerRequestId);

        if (request is null) return NotFound();

        var manpowerDonation = new ManpowerDonation
        {

            VolunteerCount = manpowerDonationDto.VolunteerCount,
            ManpowerRequest = request,
            User = user
        };

        _dbContext.ManpowerDonations.Add(manpowerDonation);

        // Update the request object
        request.VolunteerCount -= manpowerDonationDto.VolunteerCount;

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequests), manpowerDonation.ToManpowerDonationDto());
    }
}
