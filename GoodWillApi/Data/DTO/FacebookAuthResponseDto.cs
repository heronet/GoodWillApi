using System.Text.Json.Serialization;

namespace GoodWillApi.Data.DTO;

public class FacebookAuthResponseDto
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;

    [JsonPropertyName("expires_in")]
    public long ExpiresIn { get; set; }

    [JsonPropertyName("auth_type")]
    public string AuthType { get; set; } = string.Empty;
}
