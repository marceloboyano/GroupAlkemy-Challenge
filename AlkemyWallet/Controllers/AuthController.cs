﻿using AlkemyWallet.Core.Interfaces;
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

    /// <summary>
    /// Retrieve the token of a logged-in user
    /// </summary>
    /// <returns>If executed correctly, it returns a token</returns>
    [HttpPost("login")]
    public async Task<IActionResult> AuthenticateAsync([FromForm] AuthenticationRequestDTO request)
    {
        return Ok(await _iAccountsServiceJwt.AuthenticateAsync(new AuthenticationRequestDTO
        {
            Email = request.Email,
            Password = request.Password
        }));
    }

    /// <summary>
    /// Retrieves authenticated user data
    /// </summary>
    /// <returns>If executed correctly, it returns the authenticated user data</returns>
    [HttpGet("me")]
    [Authorize(Roles = "Administrador, Standard, Invitado")]
    public async Task<IActionResult> GetAuthenticatedUser()
    {
        List<Claim> userdataToken = HttpContext.User.Claims.ToList();

        return Ok(await _iAccountsServiceJwt.AuthenticatedUserAsync(userdataToken));
    }
}