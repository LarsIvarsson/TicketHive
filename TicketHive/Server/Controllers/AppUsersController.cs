using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TicketHive.Server.Repo;

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

		/// <summary>
		/// Retrieves the country of a user by username asynchronously from the repository and returns it as an HTTP ActionResult.
		/// </summary>
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

		/// <summary>
		/// Changes the password or country of a user by username asynchronously in the repository and returns an HTTP ActionResult.
		/// </summary>
	
		[HttpPut("{AppUsername}")]

		
		public async Task<ActionResult<string?>> ChangePasswordAsync(string AppUsername, [FromBody] string jsonList)
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
						return Ok("Password was changed successfully!");
					}
				}
				result = await repo.PutAppUserAsync(AppUsername, words[0]);
				if (result)
				{
					return Ok("Country was changed succcessfully!");
				}
			}
			return BadRequest("Something went wrong...");
		}
	}
}