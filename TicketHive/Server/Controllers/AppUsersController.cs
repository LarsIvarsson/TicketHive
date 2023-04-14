using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketHive.Server.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TicketHive.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepo repo;

        public AppUsersController(IAppUserRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("{AppUsername}")]
        public async Task<ActionResult<string?>> GetUserCountryByUsernameAsync(string AppUsername)
        {
            var result = await repo.GetUserByUsernameAsync(AppUsername);

            if (result != null)
            {
                string country = result.Country;

                if (country != null)
                {
                    return Ok(country);
                }
            }
            return NotFound();
        }

        [HttpPut("{AppUsername}")]
        public async Task<IActionResult> ChangePasswordAsync(string AppUsername, [FromBody] string jsonList)
        {
            bool result;
            List<string>? words = JsonConvert.DeserializeObject<List<string>>(jsonList);

            if (words != null)
            {
                if (words.Count() > 1)
                {
                    result = await repo.ChangePasswordAsync(AppUsername, words[0], words[1]);
                    if (result)
                    {
                        return Ok();
                    }
                }

                result = await repo.PutAppUserAsync(AppUsername, words[0]);

                if (result)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}