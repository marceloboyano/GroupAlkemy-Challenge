using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITransactionService _transactionService;
    private readonly IUserService _userService;

    public TransactionsController(ITransactionService transactionService, IMapper mapper, IUserService userService)
    {
        _transactionService = transactionService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetTransactions()
    {
        var userId =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transactions = await _transactionService.GetTransactions(userId);
        var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        var users = await _userService.GetById(userId);
        if (users.Id.Equals(userId))
        {
            var transact = transactionsForShow.Where(x => x.User_id.Equals(userId)).AsEnumerable().OrderBy(x => x.Date);
            return Ok(new { users.First_name, users.Last_name, transact });
        }

        return BadRequest("Inaccessible User Story");
    }


    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTransactionsById(int id)
    {
        var userId =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var trans = await _transactionService.GetTransactionById(id, userId);
        if (trans is null) return NotFound("No existe ningun catalogo con el id especificado");
        var transForShow = _mapper.Map<TransactionDTO>(trans);
        return Ok(transForShow);
    }
}