using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AlkemyWallet.Core.Helper.Constants;

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

    /// <summary>
    ///     Lists transactions made by the user making the request ordered by date over page
    /// </summary>
    /// <param name="page">Page number starting in 1</param>
    /// <returns>Transactions page list ordered by date</returns>
    [HttpGet]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetTransactionsPaging(int page)
    {
        var userId =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transactions =
            await _transactionService.GetTransactionsPaging(userId, page <= 0 ? page = PageListed.PAGE : page, PageListed.PAGESIZE);
        if (transactions.totalPages < page) return NotFound(CAT_NOT_FOUND_PAGE);
        var transactionsForShow = _mapper.Map<IEnumerable<TransactionDTO>>(transactions.recordList);
        var pagedTransactions = new PageListed(page, transactions.totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "Transactions", null, "https"));
        return Ok(transactionsForShow);
    }

    /// <summary>
    ///     Obtains the details of the transaction from the id, as long as it has been carried out by the registered user
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <returns>Transaction detail</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetTransactionById(int id)
    {
        var userId =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var transaction = await _transactionService.GetTransactionById(id, userId);
        if (transaction is null) return NotFound(TRAN_NOT_EXISTS);
        var transactionForShow = _mapper.Map<TransactionDTO>(transaction);
        return Ok(transactionForShow);
    }

    /// <summary>
    ///     Deletes the transaction with the id received in the request.
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTransaction(int id)
    {
        var result = await _transactionService.DeleteTransaction(id);
        if (!result) return NotFound(TRAN_NOT_FOUND);
        return Ok(TRAN_DELETED);
    }

    /// <summary>
    ///     Updates the transaction with the id received in the request.
    /// </summary>
    /// <param name="id">Transaction Id</param>
    /// <param name="transaction">Transaction information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTransaction(int id, TransactionDTO transaction)
    {
        var tran = _mapper.Map<Transaction>(transaction);
        var result = await _transactionService.UpdateTransaction(id, tran);
        if (!result) return NotFound(TRAN_NOT_FOUND);
        return Ok(TRAN_UPDATED);
    }

    /// <summary>
    ///     Creates the transaction.
    /// </summary>
    /// <param name="transaction">Transaction information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> InsertTransaction(TransactionDTO transaction)
    {
        transaction.Transaction_id = null;
        var tran = _mapper.Map<Transaction>(transaction);
        var result = await _transactionService.InsertTransaction(tran);
        if (!result) return NotFound(TRAN_NOT_CREATED);
        return Ok(TRAN_CREATED);
    }
}