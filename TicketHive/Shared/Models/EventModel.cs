namespace TicketHive.Shared.Models
{
	public class EventModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public CategoryEnum Type { get; set; }
		public DateTime Date { get; set; }
		public string Venue { get; set; } = null!;
		public int Price { get; set; }
		public int Capacity { get; set; }
		public bool IsSoldOut { get; set; }
		public List<UserModel>? EventUsers { get; set; } = new();
		public string? ImageUrl { get; set; }
    }
}