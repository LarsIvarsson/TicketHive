using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repo
{
	public class UserRepo : IUserRepo
	{
		private readonly EventsDbContext context;

        public UserRepo(EventsDbContext context)
		{
			this.context = context;
        }
		public async Task<List<UserModel>?> GetUsersAsync()
		{
			return await context.Users.Include(u => u.UserEvents).ToListAsync();
		}
		public async Task<UserModel?> GetUserByUsernameAsync(string UserName)
		{
			return await context.Users.Include(e => e.UserEvents).FirstOrDefaultAsync(u => u.Username == UserName);
		}

		public async Task<bool> PostUserAsync(UserModel model)
		{
			try
			{
				await context.Users.AddAsync(model);
				await context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public async Task<bool> PutUserAsync(int id, UserModel model)
		{
			UserModel? userToUpdate = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
			if (userToUpdate != null)
			{
				userToUpdate.UserEvents = model.UserEvents;
				await context.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
