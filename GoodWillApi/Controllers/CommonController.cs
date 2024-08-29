using System.Security.Claims;
using GoodWillApi.Data;
using GoodWillApi.Data.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWillApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CommonController(GoodDbContext dbContext) : ControllerBase
{
    private readonly GoodDbContext _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult> GetDonations()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));

        if (user is null) return NotFound();

        var bdonations = await _dbContext.BloodDonations
            .Where(d => d.UserId == Guid.Parse(userId))
            .Include(d => d.BloodRequest)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        var mdonations = await _dbContext.ManpowerDonations
            .Where(d => d.UserId == Guid.Parse(userId))
            .Include(d => d.ManpowerRequest)
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();

        List<LogItem> log = bdonations.Select(d => new LogItem { Place = d.BloodRequest.PlaceName, Count = d.BagCount, Incident = null, Type = "Blood" }).ToList();

        log.AddRange(mdonations.Select(d => new LogItem { Place = d.ManpowerRequest.PlaceName, Count = d.VolunteerCount, Incident = d.ManpowerRequest.IncidentType, Type = "Manpower" }));

        return Ok(log);
    }

}
