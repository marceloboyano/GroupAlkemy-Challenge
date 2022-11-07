namespace AlkemyWallet.Core.Models.DTO.UserLogin;

public class AuthenticationRequestDTO
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}