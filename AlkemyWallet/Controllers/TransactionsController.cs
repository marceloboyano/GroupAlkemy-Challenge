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
    #region Messages
    private const string TRAN_NOT_EXISTS = "No existe una transacción con el id proporcionado asociada al usuario";
    private const string TRAN_DELETED = "La transacción ha sido eliminada";
    private const string TRAN_NOT_FOUND = "No se encontró la transacción";
    private const string TRAN_UPDATED = "Transacción modificada con éxito";
    private const string TRAN_CREATED = "Transacción creada con éxito";
    private const string TRAN_NOT_CREATED = "Transacción incorrecta. No se procedió con la creación";


    #endregion

    private readonly IMapper _mapper;
    private readonly ITransactionService _transactionService;
    
    public TransactionsController(ITransactionService transactionService, IMapper mapper)
    {
        _transactionService = transactionService;
        _mapper = mapper;
    }

    /// <summary>
    /// Lists transactions made by the user making the request ordered by date
    /// </summary>
    /// <returns>Transactions list ordered by date</returns>
    [HttpGet]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetTransactions()
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transactions = await _transactionService.GetTransactions(userId);
        var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        return Ok(transactionsForShow);
    }

    /// <summary>
    /// Lists transactions made by the user making the request ordered by date over page
    /// </summary>
    /// <param name="page">Page number starting in 0</param>
    /// <returns>Transactions page list ordered by date</returns>
    [HttpGet]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetTransactionsPaging(int page)
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transactions = await _transactionService.GetTransactionsPaging(userId, page, 10);
        var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        return Ok(transactionsForShow);
    }

    /// <summary>
    /// Obtains the details of the transaction from the id, as long as it has been carried out by the registered user
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <returns>Transaction detail</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetTransactionById(int id)
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transaction = await _transactionService.GetTransactionById(id, userId);
        if (transaction is null) return NotFound(TRAN_NOT_EXISTS);
        var transactionForShow = _mapper.Map<TransactionDTO>(transaction);
        return Ok(transactionForShow);
    }

    /// <summary>
    /// Deletes the transaction with the id received in the request.
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTransaction(int id)
    {
        var result = await _transactionService.DeleteTransaction(id);
        if (!result) return BadRequest(TRAN_NOT_FOUND);
        return Ok(TRAN_DELETED);
    }

    /// <summary>
    /// Updates the transaction with the id received in the request.
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <param name="transaction">Transaction information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTransaction(int id, [FromForm] TransactionDTO transaction)
    {
        Transaction tran = _mapper.Map<Transaction>(transaction);
        var result = await _transactionService.UpdateTransaction(id, tran);
        if (!result) return NotFound(TRAN_NOT_FOUND);
        return Ok(TRAN_UPDATED);
    }

    /// <summary>
    /// Creates the transaction.
    /// </summary>
    /// <param name="transaction">Transaction information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> InsertTransaction([FromForm] TransactionDTO transaction)
    {
        transaction.Transaction_id = null;
        Transaction tran = _mapper.Map<Transaction>(transaction);
        var result = await _transactionService.InsertTransaction(tran);
        if (!result) return NotFound(TRAN_NOT_CREATED);
        return Ok(TRAN_CREATED);
    }
}
