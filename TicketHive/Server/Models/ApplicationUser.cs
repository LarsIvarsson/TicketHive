using Microsoft.AspNetCore.Identity;

namespace TicketHive.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Country { get; set; }
	}
}