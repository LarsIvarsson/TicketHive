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

		// GET api/<AppUsersController>/5
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
		// PUT api/<AppUsersController>/5
		[HttpPut("{AppUsername}")]
		public async Task<IActionResult> PutAppUserAsync(string AppUsername, [FromBody] string Country)
		{
			var result = await repo.PutAppUserAsync(AppUsername, Country);
			if (result)
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpPut("{AppUsername}")]
		public async Task<IActionResult> ChangePasswordAsync(string AppUsername, [FromBody] string jsonList)
		{
			List<string>? passwords = JsonConvert.DeserializeObject<List<string>>(jsonList);

			if (passwords != null)
			{
				var result = await repo.ChangePasswordAsync(AppUsername, passwords[0], passwords[1]);
				if (result)
				{
					return Ok();
				}
			}

			return BadRequest();
		}





		// GET: api/<AppUsersController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}
		// POST api/<AppUsersController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}
		// DELETE api/<AppUsersController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
