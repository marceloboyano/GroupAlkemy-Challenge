using AlkemyWallet.Core.Interfaces;
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
            getPage.HasPrevious ? Url.Link("GetFixTermDeposit", new { Page = pRp.Page - 1, pRp.PageSize }) : null;

        var HasNext = getPage.HasNext
            ? Url.Link("GetFixTermDeposit", new { Page = pRp.Page + 1, pRp.PageSize }) : null;

        var HasDefault = Url.Link("GetFixTermDeposit", new { page = pRp.Page, pageSize = pRp.PageSize });

        var metadata = new
            {  getPage.CurrentPage, HasPrev, HasNext , getPage.TotalPages, getPage.PageSize };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(getPage);
    }
}
