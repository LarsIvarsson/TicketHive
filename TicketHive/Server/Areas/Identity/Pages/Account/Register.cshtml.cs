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

		public List<string>? Errors { get; set; }
		public List<string> Countries { get; set; } = new();

		public RegisterModel(SignInManager<ApplicationUser> signInManager, IUserRepo repo)
		{
			this.signInManager = signInManager;
			this.repo = repo;
		}

		public void OnGet()
		{
			PopulateCountries();
		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				// try to create ApplicationUser
				var registerResult = await signInManager.UserManager.
					CreateAsync(new ApplicationUser() { UserName = Username!, Country = Country! }, Password!);

				if (registerResult.Succeeded)
				{
					// if AppUser was created, create UserModel with same Username
					await repo.PostUserAsync(new UserModel() { Username = Username! });

					// try to sign in with created AppUser
					var signInResult = await signInManager.
						PasswordSignInAsync(Username!, Password!, false, false);

					if (signInResult.Succeeded)
					{
						return Redirect("~/home");
					}
				}

				else
				{
					foreach (var e in registerResult.Errors)
					{
						Errors.Add(e.Description.ToString());
					}
				}
			}

			PopulateCountries();
			return Page();
		}

		private void PopulateCountries()
		{
			foreach (var type in Enum.GetNames(typeof(CountryEnum)))
			{
				Countries.Add(type);
			}
		}
	}
}