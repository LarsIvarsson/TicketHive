﻿using TicketHive.Server.Models;

namespace TicketHive.Server.Repo
{
    public interface IAppUserRepo
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string AppUsername);
    }
}