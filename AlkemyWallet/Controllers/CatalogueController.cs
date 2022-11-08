using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCatalogue()
    {
        var catalogues = await _catalogueService.GetCatalogues();

        var catalogueForShow = _mapper.Map<IEnumerable<CatalogueDTO>>(catalogues);
        return Ok(catalogueForShow);
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


        return Ok(catalogue);
    }
    /// <summary>
    /// Creates the Catalogue.
    /// </summary>
    /// <param name="catalogueDTO">Catalogue information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<ActionResult> PostCatalogue([FromForm] CatalogueForCreationDTO catalogueDTO)
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
            return BadRequest("no se encontro el catalogo");

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
    public async Task<ActionResult> PutCatalogue(int id, [FromForm] CatalogueForUpdateDTO catalogueDTO)
    {
        var result = await _catalogueService.UpdateCatalogues(id, catalogueDTO);
        if (!result) return NotFound("Catalogo No Encontrado");
        return Ok("Catalogo Modificado con exito");
    }
}