using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AlkemyWallet.Core.Helper.Constants;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("FixedTermDeposit")]
public class FixedTermDepositController : Controller
{
    private readonly IMapper _mapper;
    private readonly IFixedTermDepositService _fixedTermDepositService;

    public FixedTermDepositController(IFixedTermDepositService fixedTermDepositService, IMapper mapper)
    {
        _fixedTermDepositService = fixedTermDepositService;
        _mapper = mapper;
    }


    /// <summary>
    ///     Returns all investments made by a user, sorted by date.
    /// </summary>
    /// <param name="page">Page number starting in 1</param>
    /// <returns>returns all investments made by a user</returns>
    [Authorize(Roles = "Standard")]
    [HttpGet]
    public async Task<IActionResult> GetFixedTermDepositByUserId(int page)
    {
        var userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var result = await _fixedTermDepositService.GetFixedTermDepositsPaging(userId, page <= 0 ? page = PageListed.PAGE : page, PageListed.PAGESIZE);
        if (result.totalPages < page) return NotFound(CAT_NOT_FOUND_PAGE);
        var resultDTO = _mapper.Map<IEnumerable<DepositForShowDTO>>(result.recordList);
        var pagedTransactions = new PageListed(page, result.totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "FixedTermDeposit", null, "https"));
        return Ok(resultDTO);
    }

    /// <summary>
    ///     Obtains an investment with its details as long as it is an investment made by the user.
    /// </summary>
    /// <returns>returns the investment made by the user</returns>
    [Authorize(Roles = "Standard")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFixedTermDepositById(int id)
    {
        var userIdFromToken =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var fixedTermDeposit = await _fixedTermDepositService.GetFixedTermDepositsById(id, userIdFromToken);
        if (fixedTermDeposit is null)
            return NotFound(FIX_NOT_FOUND_OR_USER_INVALID_MESSAGE);
        var fixedTermDepositForShow = _mapper.Map<FixedTermDepositForShowDTO>(fixedTermDeposit);
        return Ok(fixedTermDepositForShow);
    }

    /// <summary>
    ///     Delete an investment with the id passed by parameter.
    /// </summary>
    /// <param name="id">Investment Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteFixedTermDeposit(int id)
    {
        var result = await _fixedTermDepositService.DeleteFixedTermDeposit(id);

        if (!result)
            return NotFound(FIX_NOT_FOUND_MESSAGE);

        return Ok(FIX_DELETED_MESSAGE);
    }

    /// <summary>
    ///     update an investment made with the sent id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="depositDTO"></param>
    /// <returns></returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> PutFixedTermDeposit(int id, [FromForm] DepositForUpdateDTO depositDTO)
    {
        var result = await _fixedTermDepositService.UpdateDeposit(id, depositDTO);
        if (!result) return NotFound(FIX_NOT_FOUND_MESSAGE);
        return Ok(FIX_SUCCESSFUL_MODIFIED_MESSAGE);
    }

    /// <summary>
    ///     Create a new investment
    /// </summary>
    /// <param name="depositDTO"></param>
    /// <returns></returns>
    [Authorize(Roles = "Standard")]
    [HttpPost]
    public async Task<ActionResult> PostFixedTermDeposit([FromForm] DepositForCreationDTO depositDTO)
    {
        await _fixedTermDepositService.InsertFixedTermDeposit(depositDTO);
        return Ok(FIX_SUCCESSFUL_MESSAGE);
    }
}