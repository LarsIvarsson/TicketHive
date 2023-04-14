using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.Models
{
	public class UserPasswordsModel
	{
		public string Username { get; set; } = null!;
		[Required(ErrorMessage = "Please enter your current password")]
		public string CurrentPassword { get; set; } = null!;
		[Required(ErrorMessage = "Please enter your new password")]
		public string NewPassword { get; set; } = null!;
	}
}