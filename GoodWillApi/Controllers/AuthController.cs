using GoodWillApi.Data;
using GoodWillApi.Data.DTO;
using GoodWillApi.Models;
using GoodWillApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWillApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(GoodDbContext dbContext, TokenService tokenService) : ControllerBase
{
    public readonly GoodDbContext _dbContext = dbContext;
    public readonly TokenService _tokenService = tokenService;

    [HttpPost("sso")]
    public async Task<ActionResult> FacebookSSO(RegisterDto dto)
    {
        using var client = new HttpClient();

        var appId = Environment.GetEnvironmentVariable("FACEBOOK_CLIENT_ID");
        var appSecret = Environment.GetEnvironmentVariable("FACEBOOK_CLIENT_SECRET");

        // Exchange ID Token for Access Token
        var requestUri = $"https://graph.facebook.com/v18.0/oauth/access_token?client_id={appId}&redirect_uri={dto.RedirectUrl}&client_secret={appSecret}&code={dto.Code}";
        var response = await client.GetAsync(requestUri);
        var resData = await response.Content.ReadFromJsonAsync<FacebookAuthResponseDto>();

        var userRes = await client.GetAsync($"https://graph.facebook.com/me?fields=id,name,email&access_token={resData?.AccessToken}");
        var userData = await userRes.Content.ReadFromJsonAsync<FacebookUserDto>();

        if (userData is null) return Unauthorized("User Not Found");

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userData.Email);

        if (user is null)
        {
            // New user
            user = new User
            {
                Email = userData.Email,
                Name = userData.Name,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        var token = _tokenService.GenerateToken(user);

        return Ok(new { Token = token });
    }
}
