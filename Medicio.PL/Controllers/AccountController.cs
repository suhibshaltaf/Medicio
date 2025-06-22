using Medicio.DAL.Models;
using Medicio.PL.Helpers;
using Medicio.PL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medicio.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult>Register(RegisterVM model)
        {
            if (ModelState.IsValid) {

                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
            var result= await  userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {

                    var token =await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmEmaillink = Url.Action("confirmEmail", "Account", new {userId=user.Id,token=token},protocol:HttpContext.Request.Scheme);
                    var email = new Email()
                    {
                        Subject = "confirm email",
                        Recivers = model.Email,
                        Body = $"plese confirm your account ,click :{confirmEmaillink}"
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(emailconf));
                }
            }
            return View(model);
        }
        public IActionResult emailconf()
        {
            return View();
        }
        public async Task< IActionResult> confirmEmail(string userId,string token)
        {
            if(userId == null || token == null)
            {
                return RedirectToAction("Erorr", "Home");
            }
            var user=await userManager.FindByIdAsync(userId);
            if(user is not null)
            {
                var result=await userManager.ConfirmEmailAsync(user,token);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");

                    return RedirectToAction(nameof(Login));

                }
            }
            return RedirectToAction("Erorr", "Home");

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user, model.Password);
                    if (check)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }


                }

            }
            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> SendPasswordUrl(ForgotPasswordVM model)
        {
           
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token=await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action("ResetPassword", "Account", new {email=model.Email,token=token}, "https", "localhost:7296");
                    var email = new Email()
                    {
                        Subject = "Reset Email",
                        Recivers = model.Email,
                        Body = resetPasswordUrl,
                    };
                    EmailSettings.SendEmail(email);
                }

           

            return View(model);
        }
        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordVM model) {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                    }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // أو "Index", "Home"
        }
    }
}
