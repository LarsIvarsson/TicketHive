using Microsoft.EntityFrameworkCore;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Data
{
	public class EventsDbContext : DbContext
	{
		public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options)
		{
		}

		public DbSet<EventModel> Events { get; set; }
		public DbSet<UserModel> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserModel>().HasData(new UserModel()
			{
				Id = 1,
				Username = "user"
			});
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 1,
				Name = "Justin Bieber",
				Type = CategoryEnum.Music,
				Date = DateTime.Parse("2023-07-04"),
				Venue = "Malmö Arena",
				Price = 800,
				Capacity = 3000,
				ImageUrl = "images/event/img1.avif"
			});
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 2,
				Name = "Malmö FF - IFK Göteborg",
				Type = CategoryEnum.Sport,
				Date = DateTime.Parse("2023-06-06"),
				Venue = "Eleda Stadion",
				Price = 230,
				Capacity = 22000,
                ImageUrl = "images/event/img2.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 3,
				Name = "Johan Glans Tour",
				Type = CategoryEnum.Entertainment,
				Date = DateTime.Parse("2023-08-12"),
				Venue = "Palladium",
				Price = 400,
				Capacity = 550,
                ImageUrl = "images/event/img3.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 4,
				Name = "Big Slap",
				Type = CategoryEnum.Festival,
				Date = DateTime.Parse("2023-07-04"),
				Venue = "Pildammsparken",
				Price = 700,
				Capacity = 13000,
                ImageUrl = "images/event/img4.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 5,
				Name = "Doris & Knäckebröderna",
				Type = CategoryEnum.Family,
				Date = DateTime.Parse("2023-05-04"),
				Venue = "Stadsbiblioteket Malmö",
				Price = 100,
				Capacity = 60,
                ImageUrl = "images/event/img5.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 6,
				Name = "Tom Jones",
				Type = CategoryEnum.Music,
				Date = DateTime.Parse("2023-09-04"),
				Venue = "Parken Copenhagen",
				Price = 800,
				Capacity = 26000,
                ImageUrl = "images/event/img6.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 7,
				Name = "World Padel Tour",
				Type = CategoryEnum.Sport,
				Date = DateTime.Parse("2023-10-04"),
				Venue = "Helsingborg",
				Price = 40,
				Capacity = 34,
                ImageUrl = "images/event/img7.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 8,
				Name = "Flashback Forever Live Pod",
				Type = CategoryEnum.Entertainment,
				Date = DateTime.Parse("2023-04-30"),
				Venue = "Globen",
				Price = 200,
				Capacity = 26000,
                ImageUrl = "images/event/img8.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 9,
				Name = "Babblarna The Musical",
				Type = CategoryEnum.Family,
				Date = DateTime.Parse("2023-05-14"),
				Venue = "Malmö Live",
				Price = 120,
				Capacity = 300,
                ImageUrl = "images/event/img9.avif"
            });
			modelBuilder.Entity<EventModel>().HasData(new EventModel()
			{
				Id = 10,
				Name = "Sweden Rock",
				Type = CategoryEnum.Festival,
				Date = DateTime.Parse("2023-07-04"),
				Venue = "Norje",
				Price = 500,
				Capacity = 12000,
                ImageUrl = "images/event/img10.avif"
            });
		}
	}
}
