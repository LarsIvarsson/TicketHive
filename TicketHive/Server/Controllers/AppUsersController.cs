using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<AppUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AppUsersController>/5
        [HttpGet("{AppUsername}")]
        public async Task<ActionResult<string?>> GetUserCountryByUsernameAsync(string AppUsername)
        {
            var result = await repo.GetUserCountryByUsernameAsync(AppUsername);

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

        // POST api/<AppUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
