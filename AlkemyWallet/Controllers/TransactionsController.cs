using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AlkemyWallet.Entities;
using AlkemyWallet.Core.Services;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{

    private const string TRAN_NOT_EXISTS = "No existe una transacción con el id proporcionado asociada al usuario";
    private const string TRAN_DELETED = "La transacción ha sido eliminada";
    private const string TRAN_NOT_FOUND = "No se encontró la transacción";
    private const string TRAN_UPDATED = "Transacción modificada con éxito";


    #endregion

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
        if (trans is null) return NotFound(TRAN_NOT_EXISTS);
        var transForShow = _mapper.Map<TransactionDTO>(trans);
        return Ok(transForShow);
    }

    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTransaction(int id)
    {
        var result = await _transactionService.DeleteTransaction(id);
        if (!result) return BadRequest(TRAN_NOT_FOUND);
        return Ok(TRAN_DELETED);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTransaction(int id, [FromForm] TransactionDTO transaction)
    {
        Transaction tran = _mapper.Map<Transaction>(transaction);
        var result = await _transactionService.UpdateTransaction(id, tran);
        if (!result) return NotFound(TRAN_NOT_FOUND);
        return Ok(TRAN_UPDATED);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> InsertTransaction([FromForm] TransactionDTO transaction)
    {
        transaction.Transaction_id = null;
        Transaction tran = _mapper.Map<Transaction>(transaction);
        await _transactionService.InsertTransaction(tran);
        return Ok();

    }
}
