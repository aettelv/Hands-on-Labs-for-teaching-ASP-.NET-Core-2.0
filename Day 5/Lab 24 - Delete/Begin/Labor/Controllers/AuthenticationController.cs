using Core;
using Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Labor.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                if (Employees.IsValidUser(u))
                {
                    await setIdentity(u);
                    HttpContext.Session.SetString("SessionKeyName", u.UserName);
                    return RedirectToAction("Index", "Employee");
                }
                ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                return View("Login");
            }
            return View("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(scheme: "AuthScheme");
            return RedirectToAction("Login");
        }

        private async Task setIdentity(UserDetails u)
        {
            List<Claim> claims = new List<Claim> { new Claim(ClaimTypes.Name, u.UserName) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(
                scheme: "AuthScheme",
                principal: principal);
        }

    }
}