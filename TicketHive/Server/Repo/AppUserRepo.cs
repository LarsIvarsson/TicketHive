using Microsoft.EntityFrameworkCore;
using System;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

namespace TicketHive.Server.Repo
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly ApplicationDbContext context;

        public AppUserRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser?> GetUserCountryByUsernameAsync(string AppUsername)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.UserName == AppUsername);
        }
    }
}
