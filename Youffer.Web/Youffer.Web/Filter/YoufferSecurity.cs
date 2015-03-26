//-----------------------------------------------------------------------------------------
// <copyright file="YoufferSecurity.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the YoufferSecurity type
// </summary>
//-----------------------------------------------------------------------------------------    

using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using Youffer.Resources.Models;
using Youffer.Web.Common.Helper;
using Youffer.Web.Models;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Filter
{
    /// <summary>
    /// Defines type YoufferSecurity
    /// </summary>
    public static class YoufferSecurity
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public static string UserId
        {
            get
            {
                return GetYoufferUser().UserId;
            }
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public static string UserName
        {
            get
            {
                return GetYoufferUser().UserName;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is authenticated; otherwise, <c>false</c>.
        /// </value>
        public static bool IsAuthenticated
        {
            get
            {
                return string.IsNullOrEmpty(GetYoufferUser().UserId) ? false : true;
            }
        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>WebYoufferUserModel</returns>
        public static WebYoufferUserModel Register(WebRegisterModel model, HttpResponseBase response)
        {
            WebRegisterModel registerResult = new YoufferProvider().RegisterUser(model);
            WebYoufferUserModel userModel = new WebYoufferUserModel();
            if (string.IsNullOrEmpty(registerResult.ErrorMessage))
            {
                LoginModel loginModel = new LoginModel() { Email = registerResult.Email, Password = registerResult.Password };
                userModel = Login(loginModel, response);
        }
            else
            {
                userModel.ErrorMessage = registerResult.ErrorMessage;
            }

            return userModel;
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>WebYoufferUserModel</returns>
        public static WebYoufferUserModel Login(LoginModel model, HttpResponseBase response)
        {
            //return new YoufferProvider().Login(model);
            WebYoufferUserModel user = new WebYoufferUserModel();
            bool IsLogin = Membership.ValidateUser(model.Email, model.Password);
            user = YoufferSecurity.GetYoufferUser();
            if (IsLogin)
            {
                // Create the authentication ticket with custom user data.
                var serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(user);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        model.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(Convert.ToDouble(user.ExpiryIn)),
                        true,
                        userData,
                        FormsAuthentication.FormsCookiePath);

                // Encrypt the ticket.
                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            }

            return user; ;
        }

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="externalLoginReuslt">The external login reuslt.</param>
        /// <returns>SignInStatus</returns>
        public static SignInStatus ExternalLogin(WebExternalLoginResultModel externalLoginReuslt)
        {
            return new YoufferProvider().ExternalLogin(externalLoginReuslt);
        }

        /// <summary>
        /// Gets the youffer user.
        /// </summary>
        /// <returns>WebYoufferUserModel</returns>
        public static WebYoufferUserModel GetYoufferUser()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // The user is authenticated. Return the user from the forms auth ticket.
                return ((MyPrincipal)(HttpContext.Current.User)).User;
            }
            else if (HttpContext.Current.Items.Contains("User"))
            {
                return (WebYoufferUserModel)HttpContext.Current.Items["User"];
            }

            return new WebYoufferUserModel();
        }

        /// <summary>
        /// Logs the out.
        /// </summary>
        /// <returns>bool</returns>
        public static bool LogOut()
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                { // pankaj's code, dont delete it.
                    System.Web.HttpContext.Current.Session["PaymentConfig"] = null;
                }
                // Delete the user details from cache.
                HttpContext.Current.Session.Abandon();
                //session.Abandon();

                // Delete the authentication ticket and sign out.
                FormsAuthentication.SignOut();

                // Clear authentication cookie.
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string CurrentCurrency
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                {
                    var paymentConfig = (PaymentConfigInfoDto)System.Web.HttpContext.Current.Session["PaymentConfig"];
                    return paymentConfig.Currency.Equals("INR", StringComparison.InvariantCultureIgnoreCase) ? "₹" : "$";
                }
                return "$";
            }
        }
        public static bool IsIndianPayment {
            get {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                {
                    var paymentConfig = (PaymentConfigInfoDto)System.Web.HttpContext.Current.Session["PaymentConfig"];
                    return paymentConfig.Country.Equals("india", StringComparison.InvariantCultureIgnoreCase) ? true : false;
                }
                return false;
            }
        }
        public static int CurrentAmount
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                {
                    var paymentConfig = (PaymentConfigInfoDto)System.Web.HttpContext.Current.Session["PaymentConfig"];
                    return Convert.ToInt32(paymentConfig.Amount);
                }
                return AppSettings.Get<int>("interestPrice");
            }
        }

        public static string CurrentAmountWithCurrency
        {
            get { return string.Format("{0}{1}", CurrentCurrency, CurrentAmount); }
        }

        public static decimal ProcessingAmount
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                {
                    var paymentConfig = (PaymentConfigInfoDto)System.Web.HttpContext.Current.Session["PaymentConfig"];
                    return paymentConfig.ProcessingAmount;
                }
                return 1;
            }
        }
        public static decimal ProcessingFeePercentage
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["PaymentConfig"] != null)
                {
                    var paymentConfig = (PaymentConfigInfoDto)System.Web.HttpContext.Current.Session["PaymentConfig"];
                    return paymentConfig.ProcessingFeePercentage;
                }
                return AppSettings.Get<decimal>("processingFeePercent");
            }
        }
    }
}