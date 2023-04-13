using System.ComponentModel.DataAnnotations;

namespace TicketHive.Shared.Models
{
    public class UserCountryModel
    {
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "Please choose a country")]
        public string NewCountry { get; set; } = null!;
    }
}