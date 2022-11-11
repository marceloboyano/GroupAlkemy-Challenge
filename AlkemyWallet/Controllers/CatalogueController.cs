using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AlkemyWallet.Entities.Paged;
using Newtonsoft.Json;
using AlkemyWallet.Core.Helper;

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
    /// Lists Catalogues made by the user making the request ordered by points
    /// </summary>
    /// <returns>Catalogues list ordered by points</returns>
    //[Authorize]
    [HttpGet()]
    public async Task<IActionResult> GetCatalogue(int page)
    {
        var result = await _catalogueService.GetCataloguesPaging(page, PageListed.PAGESIZE);
        IEnumerable<CatalogueDTO> resultDTO = _mapper.Map<IEnumerable<CatalogueDTO>>(result.recordList);
        PageListed pagedTransactions = new PageListed(page, result.totalPages);
        pagedTransactions.AddHeader(Response, Url.ActionLink(null, "Catalogue", null, protocol: "https"));
        return Ok(resultDTO);
    }

   
    /// <summary>
    /// Obtains the details of the Catalagoue from the id
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <returns>Catalogue detail</returns>

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCatalogueById(int id)
    {
        var catalogue = await _catalogueService.GetCatalogueById(id);

        if (catalogue is null) return NotFound("No existe ningún catalogo con el id especificado");

        var catalogoForShow = _mapper.Map<CatalogueForShowDTO>(catalogue);
        return Ok(catalogoForShow);
       
    }

    /// <summary>
    /// List of products whose value in points is less than or equal to the user's points
    /// </summary>
    /// <returns>List of products according to the user's points</returns>
    [Authorize(Roles = "Standard")]
    [HttpGet("user")]
    public async Task<IActionResult> GetCatalogueByPoints()
    {
        int userId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);      
        var catalogue = await _catalogueService.GetCatalogueByPoints(Convert.ToInt32(userId));
        if (!catalogue.Any()) return Ok("No cuenta con los puntos suficientes para adquirir algun producto.");
        return Ok(catalogue);
    }

    /// <summary>
    /// Creates the Catalogue.
    /// </summary>
    /// <param name="catalogueDTO">Catalogue information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> PostCatalogue(CatalogueForCreationDTO catalogueDTO)
    {
        await _catalogueService.InsertCatalogue(catalogueDTO);
        return Ok("Se ha creado el Catalogo exitosamente");
    }

    /// <summary>
    /// Deletes the Catalogue with the id received in the request.
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCatalogue(int id)
    {
        var result = await _catalogueService.DeleteCatalogue(id);

        if (!result)
            return NotFound("no se encontro el catalogo");

        return Ok("el catalogo ha sido eliminada");
    }
    /// <summary>
    /// Updates the Catalogue with the id received in the request.
    /// </summary>
    /// <param name="id">Catalogue Id</param>
    /// <param name="catalogueDTO">Catalogue information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPut("{id}")]
    public async Task<ActionResult> PutCatalogue(int id, CatalogueForUpdateDTO catalogueDTO)
    {
        var result = await _catalogueService.UpdateCatalogues(id, catalogueDTO);
        if (!result) return NotFound("Catalogo No Encontrado");
        return Ok("Catalogo Modificado con exito");
    }
}