namespace TicketHive.Shared.Models
{
	public class CartItemsModel
	{
		public int EventId { get; set; }
		public string? EventName { get; set; }
		public int Price { get; set; }
		public EventModel Event { get; set; }
		public int Quantity { get; set; }
	}
}