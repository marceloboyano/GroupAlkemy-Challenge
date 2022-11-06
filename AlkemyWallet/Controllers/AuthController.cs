using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models.DTO.UserLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyWallet.Controllers
{
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
    }
}
