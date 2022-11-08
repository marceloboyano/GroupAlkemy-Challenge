using AlkemyWallet.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        //Get all accounts
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var fixedTerm = await _fixedTermDeposit.GetFixedTermDeposits();

            return Ok(fixedTerm);
        }

    }
}
