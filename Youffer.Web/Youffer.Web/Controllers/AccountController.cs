using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AutoMapper;
using Youffer.Web.Common.Helper;
using Youffer.Web.Filter;
using Youffer.Web.Models;
using Youffer.Web.Resources.ViewModel;
using Youffer.Resources.ViewModel;
using Youffer.Resources.Models;

namespace Youffer.Web.Controllers
{
    public class AccountController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            ////UserManager = userManager;
            ////SignInManager = signInManager;
        }

        // GET: /Account/Login
        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>ActionResult</returns>
        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl = "")
        {
            LoginModel login = new LoginModel();
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_Login", login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                WebYoufferUserModel user = YoufferSecurity.Login(model, Response);
                if (!string.IsNullOrEmpty(user.AccessToken))
                {
                    return Json(new { redirectTo = Url.Action("Dashboard", "Admin") });
                }

                ModelState.AddModelError("loginFail", user.ErrorMessage);
            }
            else
            {
                ModelState.AddModelError("loginFail", "The user name or password is incorrect.");
            }

            return PartialView("_Login", model);
        }

        // GET: /Account/Register
        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            WebRegisterModel registerModel = new WebRegisterModel();
            registerModel.BusinessType = BusinessTypes;
            registerModel.CountryCodeList = CommonService.GetAllCountryCallingCode();
            return PartialView("_Register", registerModel);
        }

        // POST: /Account/Register
        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(WebRegisterModel model)
        {
            model.Timezone = CookieHelper.GetCookie("timezoneoffset");
            WebYoufferUserModel user = YoufferSecurity.Register(model, Response);
            if (!string.IsNullOrEmpty(user.UserId) && string.IsNullOrEmpty(user.ErrorMessage))
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                ModelState.AddModelError("registerError", user.ErrorMessage);
                model.BusinessType = BusinessTypes;
            }

            if (Request.IsAjaxRequest())
            {
                model.BusinessType = BusinessTypes;
                model.CountryCodeList = CommonService.GetAllCountryCallingCode();
                return PartialView("_Register", model);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="external_access_token">The external_access_token.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="external_user_name">The external_user_name.</param>
        /// <param name="haslocalaccount">if set to <c>true</c> [haslocalaccount].</param>
        /// <returns>ActionResult</returns>
        [AllowAnonymous]
        public ActionResult ExternalLogin(string external_access_token, string provider, string external_user_name, bool haslocalaccount = false)
        {
            WebExternalLoginResultModel externalLoginResult = new WebExternalLoginResultModel()
            {
                ExternalAccessToken = external_access_token,
                ExternalUserName = external_user_name,
                HasLocalAccount = haslocalaccount,
                Provider = provider
            };

            if (YoufferSecurity.ExternalLogin(externalLoginResult) == SignInStatus.Success)
            {
                // Session.TimeOut= [nMinutes];
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Logs the out.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            if (YoufferSecurity.LogOut())
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Dashboard", "Admin");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            WebForgotPasswordModel model = new WebForgotPasswordModel();
            return PartialView("_ForgotPassword", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(WebForgotPasswordModel model)
        {
            StatusMessage result = UserService.ForgotPasswordRequest(model.Email);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                model.ErrorMessage = "Youffer has sent an email on your registered email id, Please check your email.";
                return PartialView("_ForgotPassword", model);
            }
            ModelState.AddModelError("ForgotPasswordStatus", result.ErrorMessage);
            return PartialView("_ForgotPassword", model);
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string id)
        {
            ViewBag.Status = TempData["Status"] ?? "";
            TempData["Status"] = string.Empty;
            return id == null ? (ActionResult)RedirectToAction("Index", "Home") : View(new ForgotPassword { ResetPwdGuid = id });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(ForgotPassword model)
        {
            StatusMessage result = UserService.UpdatePassword(model);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                if (result.IsSuccess)
                {
                    TempData["Status"] = "Password Changed Successfully.";
                }
                else
                    TempData["Status"] = "Sorry, Unable to change password. Please try again.";
            }
            else
                TempData["Status"] = "It seems this token has been used to reset password. Please retry forgot password.";
            return RedirectToAction("ResetPassword", new { id = model.ResetPwdGuid});
        }

        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            ViewBag.Status = TempData["Status"] ?? "";
            TempData["Status"] = string.Empty;
            ChangePasswordModel model = new ChangePasswordModel();
            return PartialView("ChangePassword", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            StatusMessage result = UserService.ChangePassword(model);
            if (string.IsNullOrEmpty(result.ErrorMessage))
            {
                if (result.IsSuccess)
                {
                    TempData["Status"] = "Password Changed Successfully.";
                }
                else
                    TempData["Status"] = "Sorry, Unable to change password. Please try again.";
            }
            else
                TempData["Status"] = "Sorry, Unable to change password. Please try again.";
            return RedirectToAction("ChangePassword");
        }

    }
}