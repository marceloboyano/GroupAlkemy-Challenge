using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models.DTO.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AlkemyWallet.Core.Helper.Constants;

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

    /// <summary>
    ///     Retrieve the token of a logged-in user
    /// </summary>
    /// <returns>If executed correctly, it returns a token</returns>
    [HttpPost("login")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticationRequestDTO request)
    {
        var returnToken = await _iAccountsServiceJwt.AuthenticateAsync(new AuthenticationRequestDTO
        {
            Email = request.Email,
            Password = request.Password
        });
        return returnToken.Equals("false") ? NotFound(USER_EMAIL_OR_PASSWORD_INCORRECT_MESSAGE) : Ok(returnToken);
    }

    /// <summary>
    ///     Retrieves authenticated user data
    /// </summary>
    /// <returns>If executed correctly, it returns the authenticated user data</returns>
    [HttpGet("me")]
    [Authorize(Roles = "Administrador, Standard, Invitado")]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        var userdataToken = HttpContext.User.Claims.ToList();

        return Ok(await _iAccountsServiceJwt.AuthenticatedUserAsync(userdataToken));
    }
}