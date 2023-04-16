using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.Models
{
	public class UserModel
	{
		[Key]
		public int Id { get; set; }
		public string Username { get; set; } = null!;
		public List<EventModel>? UserEvents { get; set; } = new();
	}
}