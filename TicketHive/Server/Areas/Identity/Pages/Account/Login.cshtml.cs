using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Models;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{
	[BindProperties]
	public class LoginModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> signInManager;

		[Required(ErrorMessage = "Username is required")]
		public string? Username { get; set; }
		[Required(ErrorMessage = "Password is required")]
		public string? Password { get; set; }

		public LoginModel(SignInManager<ApplicationUser> signInManager)
		{
			this.signInManager = signInManager;
		}
		public void OnGet()
		{
		}
		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var signInResult = await signInManager.
					PasswordSignInAsync(Username!, Password!, false, false);
				if (signInResult.Succeeded)
				{
					return Redirect("~/");
				}
			}
			return Page();
		}
	}
}
