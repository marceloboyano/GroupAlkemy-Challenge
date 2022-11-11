using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Models.DTO;
using AlkemyWallet.Core.Models.DTO.UserLogin;
using System.Security.Claims;

namespace AlkemyWallet.Core.Interfaces;

public interface IAccountServiceJWT
{
    Task<string> AuthenticateAsync(AuthenticationRequestDTO request);
    Task<Response<AuthenticatedUserDTO>> AuthenticatedUserAsync(List<Claim> userdataTokenList);
}