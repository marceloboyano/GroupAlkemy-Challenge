using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities.Paged;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class FixedTermDepositController : Controller
{
    private readonly IMapper _mapper;
    private readonly IFixedTermDepositService _pListS;

    public FixedTermDepositController(IFixedTermDepositService pageListService, IMapper mapper)
    {
        _pListS = pageListService;
        _mapper = mapper;
    }


    //Get all accounts
    [Authorize]
    [HttpGet(Name = "GetFixTermDeposit")]
    public IActionResult GetListPaged(int Page)
    {
        var ID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        if (Page == 0 || ID == null) Page = 1;
        var pagesiz = 1;

        PageResourceParameters pRp = new() { UserID = ID, Page = Page, PageSize = pagesiz };
        var getPage = _pListS.GetPagedFtD(pRp);

        var HasPrev =
            getPage.HasPrevious ? Url.Link("GetFixTermDeposit", new { Page = pRp.Page - 1}) : null;

        var HasNext = getPage.HasNext
            ? Url.Link("GetFixTermDeposit", new { Page = pRp.Page + 1 })
            : null;

        var metadata = new
            { getPage.CurrentPage, HasPrev, HasNext, getPage.TotalPages};

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(getPage.Select(x => new FixedTermDepositDTO
            { Id = x.Id, User_id = x.User_id, Account_id = x.Account_id, Amount = x.Amount, Creation_date = x.Creation_date,Closing_date = x.Closing_date}));
        ;
    }
}