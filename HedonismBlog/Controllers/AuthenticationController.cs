using HedonismBlog.DataAccess.Repositories;
using HedonismBlog.Models;
using HedonismBlog.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using System;

namespace HedonismBlog.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpPost]
        [Route("SubmitSignIn")]
        public async Task<IActionResult> SubmitSignin(RegisterUserViewModel viewModel)
        {
            var user = await _userRepository.GetByEmail(viewModel.Email);
            if (user == null)
                throw new AuthenticationException($"No user with the email \"{viewModel.Email}\" found");
            if (user.Password != viewModel.Password)
                throw new AuthenticationException("Wrong password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role.Name)

            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "AppCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return View("SignInSucceed", user);
        }
    }
}
