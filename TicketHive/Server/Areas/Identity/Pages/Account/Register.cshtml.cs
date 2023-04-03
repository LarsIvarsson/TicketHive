using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Models;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{

	[BindProperties]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> signInManager;

		[Required(ErrorMessage = "Username is required")]
		[MinLength(5, ErrorMessage = "Username is too short")]
		public string? Username { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(5, ErrorMessage = "Password is too short")]
		public string? Password { get; set; }
		[Required]
		[Compare(nameof(Password), ErrorMessage = "Passwords not matching")]
		public string? PasswordVerify { get; set; }

		public RegisterModel(SignInManager<ApplicationUser> signInManager)
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
				var registerResult = await signInManager.UserManager.
					CreateAsync(new ApplicationUser() { UserName = Username }, Password!);

				if (registerResult.Succeeded)
				{
					var signInResult = await signInManager.
						PasswordSignInAsync(Username!, Password!, false, false);

					if (signInResult.Succeeded)
					{
						return Redirect("~/");
					}
				}
			}
			return Page();
		}
	}
}