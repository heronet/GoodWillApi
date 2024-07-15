using System.Security.Claims;
using GoodWillApi.Data;
using GoodWillApi.Data.DTO;
using GoodWillApi.Extensions;
using GoodWillApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GoodWillApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(GoodDbContext dbContext) : ControllerBase
{
    public readonly GoodDbContext _dbContext = dbContext;

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _dbContext.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("profile")]
    public async Task<ActionResult<User>> GetProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
        if (user is null) return NotFound();
        return Ok(user.ToUserDto());
    }

    [HttpPut("profile")]
    public async Task<ActionResult<User>> UpdateProfile(UserDto userDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId is null) return Unauthorized();
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
        if (user is null) return NotFound();

        user.Name = userDto.Name ?? user.Name;
        user.PlaceName = userDto.PlaceName.IsNullOrEmpty() ? user.PlaceName : userDto.PlaceName;
        user.BloodGroup = userDto.BloodGroup ?? user.BloodGroup;
        user.Lat = userDto.Lat > 0 ? userDto.Lat : user.Lat;
        user.Lng = userDto.Lng > 0 ? userDto.Lng : user.Lng;

        _dbContext.Update(user);

        await _dbContext.SaveChangesAsync();

        return Ok(user.ToUserDto());
    }


}
