using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models.DTO.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAccountServiceJWT _iAccountsServiceJwt;

    public AuthController(IAccountServiceJWT iAccountsServiceJwt)
    {
        _iAccountsServiceJwt = iAccountsServiceJwt;
    }

    [HttpPost("login")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticationRequestDTO request)
    {
        return Ok(await _iAccountsServiceJwt.AuthenticateAsync(new AuthenticationRequestDTO
        {
            Email = request.Email,
            Password = request.Password
        }));
    }

    [HttpGet("me")]
    [Authorize(Roles = "Administrador, Standard, Invitado")]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        List<Claim> userdataToken = HttpContext.User.Claims.ToList();

        return Ok(await _iAccountsServiceJwt.AuthenticatedUserAsync(userdataToken));
    }
}