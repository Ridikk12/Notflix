using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notflix.Services.User.Interfaces;
using NotFlix2.ViewModels.AccountViewModels;

namespace NotFlix2.Controllers
{

	[AllowAnonymous]
	public class AccountController : Controller
	{
		private readonly IUserAccountService _userAccountService;
		public AccountController(IUserAccountService userAccountService)
		{
			_userAccountService = userAccountService;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody]LoginViewModel viewModel)
		{

			bool isLogged = await _userAccountService.Login(viewModel.Email, viewModel.Password);
			if (isLogged)
			{

				var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,viewModel.Email),
				new Claim(ClaimTypes.Role, "User"),
			};

				var claimsIdentity = new ClaimsIdentity(
					claims, CookieAuthenticationDefaults.AuthenticationScheme);

				var authProperties = new AuthenticationProperties
				{
					//AllowRefresh = <bool>,
					// Refreshing the authentication session should be allowed.

					//ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
					// The time at which the authentication ticket expires. A 
					// value set here overrides the ExpireTimeSpan option of 
					// CookieAuthenticationOptions set with AddCookie.

					//IsPersistent = true,
					// Whether the authentication session is persisted across 
					// multiple requests. Required when setting the 
					// ExpireTimeSpan option of CookieAuthenticationOptions 
					// set with AddCookie. Also required when setting 
					// ExpiresUtc.

					//IssuedUtc = <DateTimeOffset>,
					// The time at which the authentication ticket was issued.

					//RedirectUri = <string>

				};

				await HttpContext.SignInAsync(
					CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity),
					authProperties);

				return Json(true);
			}
			return Json(false);
		}

		[HttpPost]
		public IActionResult LogOut()
		{
			return null;
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
		{

			var result = await _userAccountService.RegisterUser(model.Email, model.Password);
			return Json(new { registerSucced = result  });
		}
	}
}