using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Server.Models;
using TicketHive.Server.Repo;
using TicketHive.Shared.Models;

namespace TicketHive.Server.Areas.Identity.Pages.Account
{

	[BindProperties]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly IUserRepo repo;

		[Required(ErrorMessage = "Username is required")]
		[MinLength(5, ErrorMessage = "Username is too short")]
		public string? Username { get; set; }
		[Required(ErrorMessage = "Password is required")]
		[MinLength(5, ErrorMessage = "Password is too short")]
		public string? Password { get; set; }
		[Required, Compare(nameof(Password), ErrorMessage = "Passwords not matching")]
		public string? PasswordVerify { get; set; }

		[Required(ErrorMessage = "Please choose country")]
		public string? Country { get; set; }

		public RegisterModel(SignInManager<ApplicationUser> signInManager, IUserRepo repo)
		{
			this.signInManager = signInManager;
			this.repo = repo;
		}

		public void OnGet()
		{

		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				var registerResult = await signInManager.UserManager.
					CreateAsync(new ApplicationUser() { UserName = Username!, Country = Country! }, Password!);
				await repo.PostUserAsync(new UserModel() { Username = Username! });
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