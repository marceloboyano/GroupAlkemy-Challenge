using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
<<<<<<< HEAD
=======
using AlkemyWallet.Core.Services;
using AlkemyWallet.Entities;
>>>>>>> dev
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // Get all users
        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var list = await _userService.GetAllUser();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
=======
        public async Task<ActionResult<User>> GetUsers()
        {
            var users = await _userService.GetAllUser();
            var usersForShow = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(usersForShow);
        }
        //Get user by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
>>>>>>> dev
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult<User>> InsertUser(User user)
        {
           if(user == null)
            {
                return BadRequest();
            }
            var addUser = await _userService.AddUser(user);
            return Ok(addUser);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id,User user)
        {
            if (id != user.Id)
            {
                return BadRequest("User Id mismatch");
            }
            var updateUser = await _userService.UpdateUser(user);
            if (updateUser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            return await _userService.UpdateUser(user);
=======
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
>>>>>>> dev
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
<<<<<<< HEAD
            var deleteUser = await _userService.GetById(id);
            if(deleteUser == null)
            {
                return NotFound($"User with Id = {id} not found");
            }
            await _userService.DeleteUser(id);
            return Ok($"User with Id ={id} deleted");
=======
            var result = await _userService.DeleteUser(id);
            if (!result) return NotFound("User not found");
            return Ok($"User with Id{id} deleted");
>>>>>>> dev
        }
    }
}