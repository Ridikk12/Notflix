using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notflix.Services.User.Interfaces;
using NotFlix.DataTransferObjects.User;
using NotFlix2.ViewModels.AccountViewModels;

namespace NotFlix2.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IMapper _mapper;
        public AccountController(IUserAccountService userAccountService, IMapper mapper)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel viewModel)
        {
            LoginResultViewModel result = new LoginResultViewModel();

            UserDto user = await _userAccountService.Login(viewModel.Email, viewModel.Password);
            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,viewModel.Email),
                new Claim(ClaimTypes.Role, "User"),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                result = PrepareUserViemModel(user, claims);

                await HttpContext.SignInAsync(
             CookieAuthenticationDefaults.AuthenticationScheme,
             new ClaimsPrincipal(claimsIdentity),
             authProperties);

                return Json(result);
            }

            result.Email = viewModel.Email;
            result.IsLogged = false;


            return Json(result);
        }

        private LoginResultViewModel PrepareUserViemModel(UserDto user, List<Claim> claims)
        {
            LoginResultViewModel result = _mapper.Map<LoginResultViewModel>(user);
            result.IsLogged = true;
            if (user.IsAdmin)
            {
                result.Roles.Add("Admin");
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            result.Roles.Add("User");
            return result;
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
            return Json(new { registerSucced = result });
        }
    }
}