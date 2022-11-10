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
public class UsersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    /// <summary>
    ///     Retrieve all users
    /// </summary>
    /// <returns>User list</returns>
    [HttpGet(Name = "GetUsers")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UserDTO>> GetUsers(int Page)
    {
        var ID = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value);
        if (Page == 0 || ID == null) Page = 1;
        var pagesiz = 1;

        PageResourceParameters pRp = new() { UserID = ID, Page = Page, PageSize = pagesiz };
        var getPage = _userService.GetPagedUser(pRp);

        var HasPrev =
            getPage.HasPrevious ? Url.Link("GetUsers", new { Page = pRp.Page - 1, pRp.PageSize }) : null;

        var HasNext = getPage.HasNext
            ? Url.Link("GetUsers", new { Page = pRp.Page + 1, pRp.PageSize })
            : null;

        var metadata = new
            { getPage.CurrentPage, HasPrev, HasNext, getPage.TotalPages, getPage.PageSize };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(getPage.Select(x => new UserDTO
            { Id = x.Id, Email = x.Email, First_name = x.First_name, Last_name = x.Last_name, Rol_id = x.Rol_id }));
    }

    /// <summary>
    ///     Retrieve the user by their ID
    /// </summary>
    /// <param name="id"> The ID of the desired User</param>
    /// <returns>User details</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }

    /// <summary>
    ///     Create a new user
    /// </summary>
    /// <param name="userDTO">Fields to create the user</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [HttpPost]
    [Authorize(Roles = "Standard")]
    public async Task<ActionResult> InsertUser([FromForm] UserForCreatoionDto userDTO)
    {
        return Ok(await _userService.AddUser(userDTO));
    }

    /// <summary>
    ///     updates the user with the received in the request
    /// </summary>
    /// <param name="id">User Id</param>
    /// <param name="userDTO">Fields to update the user</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<ActionResult> UpdateUser(int id, [FromForm] UserForUpdateDto userDTO)
    {
        return await _userService.UpdateUser(id, userDTO)
            ? Ok("Successfully Modified User")
            : NotFound("User not found");
    }

    /// <summary>
    ///     delete the user with the id received in the request
    /// </summary>
    /// <param name="id">User Id</param>
    /// <returns>If executed correctly, it returns a 200 response code.</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        return await _userService.DeleteUser(id)
            ? Ok($"User with Id {id} deleted")
            : NotFound($"User with Id {id} not found");
    }

    /// <summary>
    ///     Exchange the user's points for a product from the catalog.
    /// </summary>
    /// <param name="id">Catalog Id</param>
    /// <returns></returns>
    [HttpPut("product/{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<ActionResult> ExchangePoints(int id)
    {
        var userIdFromToken = HttpContext.User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("uid"))!.Value;
        var result = await _userService.Exchange(id, userIdFromToken);
        if (!result.Success) return NotFound(result.Message);
        return Ok(result.Message);
    }
}