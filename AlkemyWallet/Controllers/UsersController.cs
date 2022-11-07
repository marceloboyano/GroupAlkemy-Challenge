using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

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
        public async Task<ActionResult> InsertUser([FromForm]UserForCreatoionDto userDTO)
        {
            await _userService.AddUser(userDTO);
            return Ok("The User has been created successfully");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id,[FromForm]UserForUpdateDto userDTO)
        {
            var result = await _userService.UpdateUser(id, userDTO);
            if (!result) return NotFound("User not found");
            return Ok("Successfully Modified User");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {

            var deleteUser = await _userService.GetById(id);
            if(deleteUser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            await _userService.DeleteUser(id);
            return Ok($"User with Id ={id} deleted");
        }
    }
}