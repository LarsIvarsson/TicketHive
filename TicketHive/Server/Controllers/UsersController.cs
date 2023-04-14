using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Repo;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo repo;

        public UsersController(IUserRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>?>> GetUsersAsync()
        {
            var result = await repo.GetUsersAsync();
            if (result != null)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{UserName}")]
        public async Task<ActionResult<UserModel?>> GetUserByUsernameAsync(string UserName)
        {
            var result = await repo.GetUserByUsernameAsync(UserName);
            if (result != null)
            {
                return Ok(result);
            }

            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUserAsync([FromBody] UserModel model)
        {
            var result = await repo.PostUserAsync(model);
            if (result)
            {
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(int id, [FromBody] UserModel model)
        {
            var result = await repo.PutUserAsync(id, model);
            if (result)
            {
                return Ok();
            }

            else
            {
                return BadRequest();
            }
        }
    }
}