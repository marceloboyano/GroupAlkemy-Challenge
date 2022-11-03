using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Models;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var list = _userService.GetAllUser();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [HttpPost]
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