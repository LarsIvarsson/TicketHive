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
            "images/img1.avif",
            "images/img2.avif",
            "images/img3.avif",
            "images/img4.avif",
            "images/img5.avif",
            "images/img6.avif",
            "images/img7.avif",
            "images/img8.avif",
            "images/img9.avif",
            "images/img10.avif",
            "images/img11.avif",
            "images/img12.avif",
            "images/img13.avif",
            "images/img14.avif",
            "images/img15.avif",
            "images/img16.avif",
            "images/img17.avif",
            "images/img18.avif",
            "images/img19.avif",
            "images/img20.avif",
            "images/img21.avif",
            "images/img22.avif",
            "images/img23.avif",
            "images/img24.avif",
            "images/img25.avif",
            "images/img26.avif"
        };

        public EventsRepo(EventsDbContext context)
        {
            this.context = context;
        }

        public async Task<List<EventModel>?> GetEventsAsync()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<EventModel?> GetEventByIdAsync(int id)
        {
            return await context.Events.FirstOrDefaultAsync(e => e.Id == id);
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
