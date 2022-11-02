using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AccountsController: ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountsService accountsService, IMapper mapper)
        {
            _accountsService = accountsService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpPost("{id}")]
        public async Task<ActionResult> PostAccountById(int id)
        {

       
            return Ok(" transaccion exitosa");

        }
    }
}
