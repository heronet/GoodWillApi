using System.Net.Http.Headers;
using GoodWillApi.Data;
using GoodWillApi.Data.DTO;
using GoodWillApi.Models;
using GoodWillApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodWillApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(GoodDbContext dbContext, TokenService tokenService, IConfiguration configuration) : ControllerBase
{
    public readonly IConfiguration _configuration = configuration;
    public readonly GoodDbContext _dbContext = dbContext;
    public readonly TokenService _tokenService = tokenService;

    [HttpPost("facebook/sso")]
    public async Task<ActionResult> FacebookSSO(RegisterDto dto)
    {
        using var client = new HttpClient();

        var appId = _configuration["FACEBOOK_CLIENT_ID"];
        var appSecret = _configuration["FACEBOOK_CLIENT_SECRET"];

        // Exchange ID Token for Access Token
        var requestUri = $"https://graph.facebook.com/v18.0/oauth/access_token?client_id={appId}&redirect_uri={dto.RedirectUrl}&client_secret={appSecret}&code={dto.Code}";
        var response = await client.GetAsync(requestUri);

        var resData = await response.Content.ReadFromJsonAsync<OAuthResponse>();

        var userRes = await client.GetAsync($"https://graph.facebook.com/me?fields=id,name,email&access_token={resData?.AccessToken}");

        if (!userRes.IsSuccessStatusCode) return BadRequest(new { error = userRes.Content.ToString() });

        var userData = await userRes.Content.ReadFromJsonAsync<FacebookUser>();

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
        Console.WriteLine($"Old user {user.Email}");

        var token = _tokenService.GenerateToken(user);

        return Ok(new { Token = token });
    }

    [HttpPost("google/sso")]
    public async Task<ActionResult> GoogleSSO(RegisterDto dto)
    {
        using var client = new HttpClient();

        var appId = _configuration["GOOGLE_CLIENT_ID"];
        var appSecret = _configuration["GOOGLE_CLIENT_SECRET"];

        // Exchange ID Token for Access Token
        var requestUri = "https://oauth2.googleapis.com/token";
        var response = await client.PostAsJsonAsync(requestUri, new
        {
            code = dto.Code,
            client_id = appId,
            client_secret = appSecret,
            redirect_uri = dto.RedirectUrl,
            grant_type = "authorization_code"
        });

        var resData = await response.Content.ReadFromJsonAsync<OAuthResponse>();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", resData?.AccessToken);

        var userRes = await client.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");

        if (!userRes.IsSuccessStatusCode) return BadRequest(new { error = userRes.Content.ToString() });

        var userData = await userRes.Content.ReadFromJsonAsync<GoogleUser>();

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
        Console.WriteLine($"Old user {user.Email}");

        var token = _tokenService.GenerateToken(user);

        return Ok(new { Token = token });
    }
}
