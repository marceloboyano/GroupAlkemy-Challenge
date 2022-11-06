using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITransactionService _transactionService;
    
    public TransactionsController(ITransactionService transactionService, IMapper mapper)
    {
        _transactionService = transactionService;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTransactions()
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transactions = await _transactionService.GetTransactions(userId);
        var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        return Ok(transactionsForShow);
    }


    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTransactionById(int id)
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var trans = await _transactionService.GetTransactionById(id, userId);
        if (trans is null)
        {
            return NotFound("No existe ningun catalogo con el id especificado");
        }
        var transForShow = _mapper.Map<TransactionDTO>(trans);
        return Ok(transForShow);
    }
}