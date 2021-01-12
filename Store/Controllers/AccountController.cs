using Store.Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Store.Models.Account;
using System.Threading.Tasks;
using Store.Core.Domain.StoreTables.User;
using Microsoft.AspNet.Identity;
using Store.WebEssential.Mvc;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using System.IO;
using Store.Service;
namespace Store.Controllers
{

    public class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IAuthenticationManager _authManager;
        

        public AccountController(ApplicationSignInManager signInManager, ApplicationUserManager userManager, IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }
     
        public ActionResult Login(string returnUrl = "/", bool? checkoutAsGuest = false)
        {
            var f = DateTime.Now;

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.CheckoutAsGuest = checkoutAsGuest;

            var model = new LoginViewModel();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[CaptchaMvc.Attributes.CaptchaVerify("کپچا صحیح نمی باشد")]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByName(model.Email);
                    if (user != null)
                    {
                        List<string> roles = new List<string>();

                        foreach (var item in user.ApplicationRoles)
                        {
                            roles.Add(item.Name);
                        }

                        if (!roles.Contains("admin"))
                        {
                            foreach (var role in user.ApplicationRoles)
                            {
                                if (!role.IsActive)
                                {

                                    ViewBag.error = "حساب کاربری شما مسدود شده است!";
                                    ModelState.AddModelError("error", "حساب کاربری شما مسدود شده است!");

                                    ViewBag.ReturnUrl = returnUrl;
                                    return View(model);
                                }
                                

                            }

                            if (user.UserStatus)
                            {
                              if(user.DateExpire!=null && user.DateExpire.Value.Date <= DateTime.Now.Date)
                                {
                                    ViewBag.error = "حساب کاربری شما مسدود شده است!";
                                    ModelState.AddModelError("error", "حساب کاربری شما مسدود شده است!");

                                    ViewBag.ReturnUrl = returnUrl;
                                    return View(model);
                                }
                                else
                                {

                                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                                switch (result)
                                {
                                    case Microsoft.AspNet.Identity.Owin.SignInStatus.Success:

                                        //return Json(new { success = true, message = returnUrl });
                                        return Redirect(returnUrl);
                                    //return RedirectPermanent(returnUrl);
                                    case Microsoft.AspNet.Identity.Owin.SignInStatus.LockedOut:

                                    case Microsoft.AspNet.Identity.Owin.SignInStatus.RequiresVerification:

                                    case Microsoft.AspNet.Identity.Owin.SignInStatus.Failure:

                                    default:
                                        ViewBag.error = "تلاش   ناموفق!";
                                        ModelState.AddModelError("error", "تلاش   ناموفق");
                                        break;
                                }
                                }
                            }
                            else
                            {
                                ViewBag.error = "حساب کاربری شما مسدود شده است!";
                                ModelState.AddModelError("error", "حساب کاربری شما مسدود شده است!");

                                //return Json(new { success = false, errors = "حساب کاربری شما مسدود شده است!" });

                            }
                        }

                        else
                        {
                            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                            switch (result)
                            {
                                case Microsoft.AspNet.Identity.Owin.SignInStatus.Success:

                                    //return Json(new { success = true, message = returnUrl });
                                    return Redirect(returnUrl);
                                //return RedirectPermanent(returnUrl);
                                case Microsoft.AspNet.Identity.Owin.SignInStatus.LockedOut:

                                case Microsoft.AspNet.Identity.Owin.SignInStatus.RequiresVerification:

                                case Microsoft.AspNet.Identity.Owin.SignInStatus.Failure:

                                default:
                                    ViewBag.error = "تلاش   ناموفق";

                                    ModelState.AddModelError("error", "تلاش   ناموفق");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("error", "کاربر وجود ندارد"); 
                        ViewBag.error = "کاربر وجود ندارد";
                      
                      
                    }
                }
                catch (Exception e)
                {

                    throw;
                }

            }
            if (!ModelState.IsValid)
            {
                StringBuilder builder = new StringBuilder();
                // Append to StringBuilder.
                foreach (var e in ModelState.Values)
                {

                    if (e.Errors.Count() > 0)
                    {
                        foreach (var error in e.Errors.ToList())
                        {
                            builder.Append(error.ErrorMessage).Append("\n");
                        }
                    }
                }

                //return Json(new { success = false, errors = builder.ToString() });
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Register()
        {
            _authManager.SignOut();
            var model = new RegisterViewModel();
            return View(model);
        }
     
        private void AddErrors(IdentityResult result)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("Error", err);
            }
        }
        public ActionResult LogOff()
        {
            _authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

    }
}