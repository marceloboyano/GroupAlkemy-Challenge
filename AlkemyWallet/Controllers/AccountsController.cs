using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AlkemyWallet.Core.Helper.Constants;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountsService;
    private readonly IMapper _mapper;

    public AccountsController(IAccountService accountsService, IMapper mapper)
    {
        _accountsService = accountsService;
        _mapper = mapper;
    }

    /// <summary>
    ///     lists of the accounts only accessible by an administrator account
    /// </summary>
    /// <param name="page">Page number starting in 1</param>
    /// <returns>Accounts list </returns>
    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> GetAccounts(int page)
    {
        var (totalPages, recordList) =
            await _accountsService.GetAccountsPaging(page <= 0 ? page = PageListed.PAGE : page, PageListed.PAGESIZE);
        if (totalPages < page) return NotFound(CAT_NOT_FOUND_PAGE);
        var resultDTO = _mapper.Map<IEnumerable<AccountForShowDTO>>(recordList);
        var pagedTransactions = new PageListed(page, totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "Accounts", null, "https"));
        return Ok(resultDTO);
    }

    /// <summary>
    ///     Obtains the details of the Accounts from the id
    /// </summary>
    /// <param name="id">Accounts Id</param>
    /// <returns>Accounts detail</returns>
    [Authorize(Roles = "Administrador")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(int id)
    {
        var account = await _accountsService.GetAccountById(id);

        if (account is null) return NotFound(ACC_NOT_FOUND_MESSAGE);

        return Ok(account);
    }

    /// <summary>
    ///     Creates the Accounts.
    /// </summary>
    /// <param name="accountDTO">Accountse information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Standard")]
    [HttpPost]
    public async Task<ActionResult> PostAccount(AccountForCreationDTO accountDTO)
    {
        await _accountsService.InsertAccounts(accountDTO);
        return Ok(ACC_SUCCESSFUL_ACCOUNT_MESSAGE);
    }

    /// <summary>
    ///     Updates the Accounts with the id received in the request.
    /// </summary>
    /// <param name="id">Accounts Id</param>
    /// <param name="accountDTO">Accounts information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> PutCatalogue(int id, AccountForUpdateDTO accountDTO)
    {
        var result = await _accountsService.UpdateAccount(id, accountDTO);
        if (!result) return NotFound(ACC_NOT_FOUND_MESSAGE);
        return Ok(ACC_SUCCESSFUL_ACCOUNT_MODIFIED_MESSAGE);
    }

    /// <summary>
    ///     Delete an account only if it has no pending investments or loans.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAccount(int id)
    {
        var result = await _accountsService.DeleteAccount(id);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }

    /// <summary>
    ///     Make a deposit of money into an account.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    [Authorize(Roles = "Standard")]
    [HttpPost("{id}/deposit")]
    public async Task<ActionResult> PostDeposit(int id, int amount)
    {
        var userIdFromToken = HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value;
        if (int.Parse(userIdFromToken) != id)
            return BadRequest(ACC_NOT_MATCHED_MESSAGE);

        var result = await _accountsService.Deposit(id, amount);
        if (result.Success)
            return Ok(result.Message);

        return BadRequest(result.Message);
    }

    /// <summary>
    ///     Transfer money from one account to another.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="amount"></param>
    /// <param name="toAccountId"></param>
    /// <returns></returns>
    [Authorize(Roles = "Standard")]
    [HttpPost("{id}/transfer")]
    public async Task<ActionResult> PostTransfer(int id, int amount, int toAccountId)
    {
        var userIdFromToken = HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value;
        if (int.Parse(userIdFromToken) != id)
            return BadRequest(ACC_NOT_MATCHED_MESSAGE);

        var result = await _accountsService.Transfer(id, amount, toAccountId);
        if (result.Success)
            return Ok(result.Message);
        return BadRequest(result.Message);
    }

    /// <summary>
    ///     Block an account so that it cannot carry out operations.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Roles = "Standard")]
    [HttpPut("block/{id}")]
    public async Task<ActionResult> BlockAccount(int id)
    {
        var result = await _accountsService.Block(id);
        if (!result.Success) return NotFound(result.Message);
        return Ok(result.Message);
    }

    /// <summary>
    ///     Unblock an account so that it cannot carry out operations.
    /// </summary>
    /// <param name="id">Account Id</param>
    /// <returns></returns>
    [Authorize(Roles = "Standard")]
    [HttpPut("unblock/{id}")]
    public async Task<ActionResult> UnblockAccount(int id)
    {
        var result = await _accountsService.Unblock(id);
        if (!result.Success) return NotFound(result.Message);
        return Ok(result.Message);
    }
}