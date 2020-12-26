using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.API.Repositories;
using eShop_Core.Entities;
using Users.API.Model.Responses;
using Users.API.Model.Requests;
using Users.API.Utils;

namespace eShop_Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            List<User> users = await userRepository.GetUsers();
            return Ok(users.Select(u => u.ToUserResponse()));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var user = await userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToUserResponse());
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            if (id != updateUserRequest.Id)
            {
                return BadRequest();
            }

            if(!userRepository.UserExists(id))
            {
                return NotFound();
            }

            await userRepository.UpdateUser(updateUserRequest.ToUser());

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUser(User user)
        {
            await userRepository.AddUser(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUser(int id)
        {
            var user = await userRepository.GetUser(id);
            
            if (user == null)
            {
                return NotFound();
            }

            await userRepository.DeleteUser(user);

            return Ok(user.ToUserResponse());
        }

    }
}
