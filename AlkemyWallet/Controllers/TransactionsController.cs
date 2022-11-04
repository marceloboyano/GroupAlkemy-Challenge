using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Services;
using AlkemyWallet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransactionsController: ControllerBase
    {
        
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            int userId = 2;
            var transactions = await _transactionService.GetTransactions(userId);
            //var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
            //return Ok(transactionsForShow);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionsById(int id)
        {
            return BadRequest();
        }
        
    }
}

