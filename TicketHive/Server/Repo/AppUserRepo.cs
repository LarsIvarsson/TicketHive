using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

namespace TicketHive.Server.Repo
{
	public class AppUserRepo : IAppUserRepo
	{
		private readonly ApplicationDbContext context;
		private readonly SignInManager<ApplicationUser> manager;

		public AppUserRepo(ApplicationDbContext context, SignInManager<ApplicationUser> manager)
		{
			this.context = context;
			this.manager = manager;
		}

		public async Task<ApplicationUser?> GetUserByUsernameAsync(string AppUsername)
		{
			return await context.Users.FirstOrDefaultAsync(u => u.UserName == AppUsername);
		}

		public async Task<bool> PutAppUserAsync(string AppUsername, string Country)
		{
			ApplicationUser? appUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == AppUsername);
			if (appUser != null)
			{
				appUser.Country = Country;
				await context.SaveChangesAsync();
				return true;
			}
			return false;
		}

		public async Task<bool> ChangePasswordAsync(string AppUsername, string currentPassword, string newPassword)
		{
			ApplicationUser? appUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == AppUsername);
			if (appUser != null)
			{
				var result = await manager.UserManager.
					ChangePasswordAsync(appUser, currentPassword, newPassword);
				if (result.Succeeded)
				{
					return true;
				}
			}
			return false;
		}
	}
}
