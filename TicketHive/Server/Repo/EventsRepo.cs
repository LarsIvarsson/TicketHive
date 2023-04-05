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
			"/images/event/img1.avif",
			"/images/event/img2.avif",
			"/images/event/img3.avif",
			"/images/event/img4.avif",
			"/images/event/img5.avif",
			"/images/event/img6.avif",
			"/images/event/img7.avif",
			"/images/event/img8.avif",
			"/images/event/img9.avif",
			"/images/event/img10.avif",
			"/images/event/img11.avif",
			"/images/event/img12.avif",
			"/images/event/img13.avif",
			"/images/event/img14.avif",
			"/images/event/img15.avif",
			"/images/event/img16.avif",
			"/images/event/img17.avif",
			"/images/event/img18.avif",
			"/images/event/img19.avif",
			"/images/event/img20.avif",
			"/images/event/img21.avif",
			"/images/event/img22.avif",
			"/images/event/img23.avif",
			"/images/event/img24.avif",
			"/images/event/img25.avif",
			"/images/event/img26.avif"
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
				model.ImageUrl = SetImageUrl();

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
			int i = new Random().Next(0, 26);
			return images[i];
		}
	}
}
