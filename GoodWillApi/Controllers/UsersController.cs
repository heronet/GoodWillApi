using GoodWillApi.Data;
using GoodWillApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
}
