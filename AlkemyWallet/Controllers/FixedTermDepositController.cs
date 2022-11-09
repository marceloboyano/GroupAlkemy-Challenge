using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities.Paged;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Web.Http.Routing;
using AlkemyWallet.Core.Helper;
using AlkemyWallet.Entities;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Packaging.Licenses;


namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class FixedTermDepositController : Controller
{
    private readonly IMapper _mapper;
    private readonly IFixedTermDepositService _pageListService;

    public FixedTermDepositController(IFixedTermDepositService pageListService, IMapper mapper)
    {
        _pageListService = pageListService;
        _mapper = mapper;
    }


    //Get all accounts
    [Authorize]
    [HttpGet(Name = "GetFixTermDeposit")]
    public ActionResult GetFixTermDeposit([FromQuery] PageResourceParameters pRp)
    { 
        pRp.UserID =Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        
        var fixedTerm = _pageListService.GetFixedPaged(pRp);
        
        var previousPageLink = fixedTerm.HasPrevious ? CreateFTRUri(pRp, ResourceUriType.previousPage) : null;
        
        var nexPage = fixedTerm.HasNext ? CreateFTRUri(pRp, ResourceUriType.nextPage) : null;
        
        var paginationMetaData = new { currentPage = pRp.Page, previousPageLink, nexPage };
        
        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetaData));
        
        return Ok(fixedTerm);

    }
    private string CreateFTRUri(PageResourceParameters pRp, ResourceUriType type)
    {
        switch (type)
        {
            case ResourceUriType.previousPage:
                return Url.Link("GetFixTermDeposit", new { page = pRp.Page - 1, pageSize = pRp.PageSize });
            case ResourceUriType.nextPage:
                return Url.Link("GetFixTermDeposit", new { page = pRp.Page + 1, pageSize = pRp.PageSize });
            default:
                return Url.Link("GetFixTermDeposit", new { page = pRp.Page, pageSize = pRp.PageSize });
        }

    }
}