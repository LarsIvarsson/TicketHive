using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Repo
{
	public class EventsRepo : IEventsRepo
	{
		private readonly EventsDbContext context;
		private List<string> images = new()
		{
			"/images/event/img1.jpg",
			"/images/event/img2.jpg",
			"/images/event/img3.jpg",
			"/images/event/img4.jpg",
			"/images/event/img5.jpg",
			"/images/event/img6.jpg",
			"/images/event/img7.jpg",
			"/images/event/img8.jpg",
			"/images/event/img9.jpg",
			"/images/event/img10.jpg"
		};

		public EventsRepo(EventsDbContext context)
		{
			this.context = context;
		}

		public async Task<List<EventModel>?> GetEventsAsync()
		{
			return await context.Events.Include(e => e.EventUsers).ToListAsync();
		}

		public async Task<EventModel?> GetEventByIdAsync(int id)
		{
			return await context.Events.Include(e => e.EventUsers).FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<bool> PostEventAsync(EventModel model)
		{
			try
			{
				if(model.ImageUrl == null)
				{
                    model.ImageUrl = SetImageUrl();
                }

				await context.Events.AddAsync(model);
				await context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> PutEventAsync(int id, EventModel model)
		{
			EventModel? modelToUpdate = await context.Events.FirstOrDefaultAsync(e => e.Id == id);
			if (modelToUpdate != null)
			{
				modelToUpdate.Name = model.Name;
				modelToUpdate.Type = model.Type;
				modelToUpdate.Date = model.Date;
				modelToUpdate.Venue = model.Venue;
				modelToUpdate.Price = model.Price;
				modelToUpdate.Capacity = model.Capacity;
				modelToUpdate.ImageUrl = SetImageUrl();

				await context.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> DeleteEventAsync(int id)
		{
			EventModel? modelToDelete = await context.Events.FirstOrDefaultAsync(e => e.Id == id);
			if (modelToDelete != null)
			{
				context.Events.Remove(modelToDelete);
				await context.SaveChangesAsync();
				return true;
			}
			else
			{
				return false;
			}
		}

		private string SetImageUrl()
		{
			int i = new Random().Next(0, 10);
			return images[i];
		}
	}
}
