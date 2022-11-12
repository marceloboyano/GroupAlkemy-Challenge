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
public class CatalogueController : ControllerBase
{
    private readonly ICatalogueService _catalogueService;
    private readonly IMapper _mapper;

    public CatalogueController(ICatalogueService catalogueService, IMapper mapper)
    {
        _catalogueService = catalogueService;
        _mapper = mapper;
    }


    /// <summary>
    ///     Lists Catalogues made by the user making the request ordered by points 
    /// </summary>
    /// <param name="page">Page number starting in 1</param>
    /// <returns>Catalogues list ordered by points</returns>
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCatalogue(int page)
    {
        var result = await _catalogueService.GetCataloguesPaging(page <= 0 ? page = PageListed.PAGE : page, PageListed.PAGESIZE);    if (result.totalPages<page) return NotFound(CAT_NOT_FOUND_PAGE);
        var resultDTO = _mapper.Map<IEnumerable<CatalogueForShowDTO>>(result.recordList);
        var pagedTransactions = new PageListed(page, result.totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "Catalogue", null, "https"));
        return Ok(resultDTO);
    }


    /// <summary>
    ///     Obtains the details of the Catalagoue from the id
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <returns>Catalogue detail</returns>
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCatalogueById(int id)
    {
        var catalogue = await _catalogueService.GetCatalogueById(id);

        if (catalogue is null) return NotFound(CAT_NOT_FOUND_MESSAGE);

        var catalogoForShow = _mapper.Map<CatalogueForShowDTO>(catalogue);
        return Ok(catalogoForShow);
    }

    /// <summary>
    ///     List of products whose value in points is less than or equal to the user's points
    /// </summary>
    /// <returns>List of products according to the user's points</returns>
    [Authorize(Roles = "Standard")]
    [HttpGet("user")]
    public async Task<IActionResult> GetCatalogueByPoints()
    {
        var userId =
            Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        var catalogue = await _catalogueService.GetCatalogueByPoints(Convert.ToInt32(userId));
        if (!catalogue.Any()) 
            return BadRequest(CAT_INSUFFICIENT_POINTS_MESSAGE);
        return Ok(catalogue);
    }

    /// <summary>
    ///     Creates the Catalogue.
    /// </summary>
    /// <param name="catalogueDTO">Catalogue information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> PostCatalogue(CatalogueForCreationDTO catalogueDTO)
    {
        await _catalogueService.InsertCatalogue(catalogueDTO);
        return Ok(CAT_SUCCESSFUL_MESSAGE);
    }

    /// <summary>
    ///     Deletes the Catalogue with the id received in the request.
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCatalogue(int id)
    {
        var result = await _catalogueService.DeleteCatalogue(id);

        if (!result)
            return NotFound(CAT_NOT_FOUND_MESSAGE);

        return Ok(CAT_DELETED_MESSAGE);
    }

    /// <summary>
    ///     Updates the Catalogue with the id received in the request.
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <param name="catalogueDTO">Catalogue information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> PutCatalogue(int id, CatalogueForUpdateDTO catalogueDTO)
    {
        var result = await _catalogueService.UpdateCatalogues(id, catalogueDTO);
        if (!result) return NotFound(CAT_NOT_FOUND_MESSAGE);
        return Ok(CAT_SUCCESSFUL_MODIFIED_MESSAGE);
    }
}