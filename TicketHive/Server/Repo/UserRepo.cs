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
			// .Include(u => u.UserEvents)
		}
		public async Task<UserModel?> GetUserByUsernameAsync(string UserName)
		{
			return await context.Users.Include(e => e.UserEvents).FirstOrDefaultAsync(u => u.Username == UserName);
			// .Include(e => e.UserEvents)
		}
		public async Task<UserModel?> GetUserByUsernameIncludeEventsAsync(string UserName)
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
			UserModel? userToUpdate = await context.Users.Include(u => u.UserEvents).FirstOrDefaultAsync(u => u.Id == id);
			if (userToUpdate != null)
			{
				foreach (var ev in model.UserEvents)
				{
					// Jag undrar om Include verkligen är nödvändigt här
					EventModel? eventToAdd = await context.Events.Include(e => e.EventUsers).FirstOrDefaultAsync(e => e.Id == ev.Id);
					if (eventToAdd != null)
					{
						userToUpdate.UserEvents.Add(eventToAdd);
					}
				}
				context.Update(userToUpdate);
				// context.Entry(userToUpdate).State = EntityState.Modified;                
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
>>>>>>> master
