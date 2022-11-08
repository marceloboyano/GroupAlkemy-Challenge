using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    // Get all users
    [HttpGet]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<UserDTO>> GetUsers()
    {
        var users = await _userService.GetAllUser();
        var usersForShow = _mapper.Map<IEnumerable<UserDTO>>(users);
        return Ok(usersForShow);
    }

    //Get user by id
    [HttpGet("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    [Authorize(Roles = "Standard")]
    public async Task<ActionResult> InsertUser([FromForm] UserForCreatoionDto userDTO)
    {
        return Ok(await _userService.AddUser(userDTO));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Standard")]
    public async Task<ActionResult> UpdateUser(int id, [FromForm] UserForUpdateDto userDTO)
    {
        return await _userService.UpdateUser(id, userDTO) ? Ok("Successfully Modified User") : NotFound("User not found");
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        return await _userService.DeleteUser(id) ? Ok($"User with Id {id} deleted") : NotFound($"User with Id {id} not found");
    }
}