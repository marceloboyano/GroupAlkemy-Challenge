using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyWallet.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Lists of the Roles
    /// </summary>
    /// <returns>Roles list</returns>
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<RolesDTO>> GetRoles()
    {
        var roles = await _roleService.GetAllRoles();
        var rolesForShow = _mapper.Map<IEnumerable<RolesDTO>>(roles);
        return Ok(rolesForShow);
    }

    /// <summary>
    ///     Obtains the details of the Roles from the id
    /// </summary>
    /// <param name="id">Rol Id</param>
    /// <returns>Role detail</returns>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetRoleById(int id)
    {
        var roles = await _roleService.GetRoleById(id);
        return Ok(roles);
    }

    /// <summary>
    ///     Creates the Roles
    /// </summary>
    /// <param name="roleDTO">Roles information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [HttpPost]
    public async Task<ActionResult> InsertRole(RoleDTO roleDTO)
    {
        return Ok(await _roleService.AddRole(roleDTO));
    }

    /// <summary>
    ///     Updates the Roles with the Id received in the request
    /// </summary>
    /// <param name="id">Roles Id</param>
    /// <param name="roleDTO">Roles information</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRole(int id, RoleForUpdateDTO roleDTO)
    {
        var result = await _roleService.UpdateRole(id, roleDTO);
        if (!result) return NotFound("Role not found");
        return Ok("Successfully Modified Role");
    }

    /// <summary>
    ///     Delete a Role
    /// </summary>
    /// <param name="id">Role Id</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteRole(int id)
    {
        var deleteRole = await _roleService.GetRoleById(id);
        if (deleteRole == null) return NotFound($"Role with Id = {id} not found");
        await _roleService.DeleteRole(id);
        return Ok($"Role with Id ={id} deleted");
    }
}