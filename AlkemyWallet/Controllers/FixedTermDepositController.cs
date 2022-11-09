using AlkemyWallet.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Packaging.Licenses;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AlkemyWallet.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FixedTermDepositController : Controller
    {
        private readonly IFixedTermDepositService _fixedTermDeposit;
        private readonly IMapper _mapper;

        public FixedTermDepositController(IFixedTermDepositService fixedTermDeposit, IMapper mapper)
        {
            _fixedTermDeposit = fixedTermDeposit;
            _mapper = mapper;
        }
        //Get all FixedTermDeposits
        [HttpGet("all")]
        public async Task<IActionResult> GetAccounts()
        {
            
            var fixedTerm = await _fixedTermDeposit.GetFixedTermDeposits();

            return Ok(fixedTerm);
        }

        //Get All FixedTermDeposits from authorized a user
        [Authorize(Roles = "Standard")]
        [HttpGet]
        public async Task<IActionResult> GetFixedTermDeposits()
        {
            //get id from jwt token
            int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
            var fixedTerm = await _fixedTermDeposit.GetFixedTermDepositsByUserId(userId);
            return Ok(fixedTerm);
        }

    }
}
