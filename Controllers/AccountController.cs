﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SimpleGlossary.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        
        public AccountController(UserManager<IdentityUser> userMgr,
            SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost ("/api/account/login")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel creds)
        {
            if (ModelState.IsValid&&await DoLogin(creds))
            {
                return Ok();
            }

            return BadRequest();
        }


        [HttpPost]
        //         public async Task<IActionResult> Login(LoginViewModel creds,
        //                     string returnUrl)
        //         {
        //             System.Diagnostics.Debug.WriteLine("coming...");
        //             if (ModelState.IsValid)
        //             {
        //                 if (await DoLogin(creds))
        //                 {
        //                     return Redirect(returnUrl ?? "/");
        //                 }
        //                 else
        //                 {
        //                     ModelState.AddModelError("", "invalid username of password");
        //                 }
        //             }
        // 
        //             return View(creds);
        //         }


        [HttpPost]
        public async Task<IActionResult> Logout(string redirectUrl)
        {
            await signInManager.SignOutAsync();
            return Redirect(redirectUrl ?? "/");
        }

        [HttpPost("/api/account/logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        private async Task<bool> DoLogin(LoginViewModel creds)
        {
            IdentityUser user = await userManager.FindByNameAsync(creds.Name);
            if(user != null)
            {
                await signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(user, creds.Password, false, false);

                return result.Succeeded;
            }
            return false;
        }
    }

    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}