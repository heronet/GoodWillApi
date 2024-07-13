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
public class BloodController(GoodDbContext dbContext) : ControllerBase
{
    private readonly GoodDbContext _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult> GetRequests()
    {
        var requests = await _dbContext.BloodRequests.ToListAsync();

        return Ok(requests);
    }


    [HttpPost]
    public async Task<ActionResult> AddRequest([FromBody] BloodRequestDto bloodRequestDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));

        if (user is null) return NotFound();

        var bloodRequest = new BloodRequest
        {
            PatientName = bloodRequestDto.PatientName,
            PlaceName = bloodRequestDto.PlaceName,
            BagCount = bloodRequestDto.BagCount,
            BloodGroup = bloodRequestDto.BloodGroup,
            Lat = bloodRequestDto.Lat,
            Lng = bloodRequestDto.Lng,
            User = user
        };

        _dbContext.BloodRequests.Add(bloodRequest);

        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequests), bloodRequest.ToBloodRequestDto());
    }
}
