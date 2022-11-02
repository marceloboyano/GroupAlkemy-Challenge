using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[transactions]")]

    public class TransactionsController: ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionsService transactionsService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTransactions()
        {
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionsById(int id)
        {
            return BadRequest();
        }
    }
}

