using System.Text.Json.Serialization;

namespace AlkemyWallet.Core.Models.DTO.UserLogin;

public class AuthenticationResponseDTO
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string>? Roles { get; set; }
    public bool IsVerified { get; set; }
    public string JWToken { get; set; } = string.Empty;

    [JsonIgnore] public string RefreshToken { get; set; } = string.Empty;
}