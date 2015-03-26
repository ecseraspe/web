//-----------------------------------------------------------------------------------------
// <copyright file="YoufferProvider.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the YoufferProvider type
// </summary>
//-----------------------------------------------------------------------------------------    

using Microsoft.AspNet.Identity.Owin;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using Youffer.Web.Models;
using System.Web;
using System.Web.Mvc;
using Youffer.Web.Common.Helper;
using Youffer.Web.Controllers;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Filter
{
    /// <summary>
    /// Defines type YoufferProvider
    /// </summary>
    public class YoufferProvider : BaseController
    {
        /// <summary>
        /// Gets the youffer user.
        /// </summary>
        /// <returns>YoufferUser</returns>
        public WebYoufferUserModel GetYoufferUser()
        {
            if (System.Web.HttpContext.Current.Session[GlobalConstants.YoufferUserSession] != null)
            {
                WebYoufferUserModel user = System.Web.HttpContext.Current.Session[GlobalConstants.YoufferUserSession] as WebYoufferUserModel;
                return user;
            }

            else
                return new WebYoufferUserModel();
        }


        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException(); // Will call Service API
        }

        //public  bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>WebRegisterModel</returns>
        public WebRegisterModel RegisterUser(WebRegisterModel model)
        {
            return UserService.RegisterUser(model);
        }

        /// <summary>
        /// Note: do not call this function directly from youfferSecurity. it is calling from YoufferMembership, 
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public WebYoufferUserModel Login(string email, string password)
        {
            WebYoufferUserModel user = UserService.FormLogin(email, password);
            if (!string.IsNullOrEmpty(user.AccessToken))
            {
                return user;
            }

            return new WebYoufferUserModel() { ErrorMessage = user.ErrorMessage };
        }

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="externalLoginResult">The external login result.</param>
        /// <returns></returns>
        public SignInStatus ExternalLogin(WebExternalLoginResultModel externalLoginResult)
        {
            WebYoufferUserModel youfferUser = UserService.ExternalLogin(externalLoginResult);
            if (youfferUser != null)
            {
                if (!string.IsNullOrEmpty(youfferUser.AccessToken))
                {
                    return SignInStatus.Success;
                }
            }

            return SignInStatus.Failure;
        }

        /// <summary>
        /// Logs the out.
        /// </summary>
        public void LogOut()
        {
            try
            {
                ////var user = GetYoufferUser();
                ////user.CurrentUserId = -1;
                ////////user.CurrentUserName = string.Empty;
                ////StoreYoufferUser(user);
                ////// will delete all cookies and sessions and will redirect to HomeIndex
                //return true;
            }
            catch
            {
                //return false;
            }
        }

        //public  bool DeleteUser(string username, bool deleteAllRelatedData)
        //{
        //    throw new NotImplementedException();
        //}

        public bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public void GetUser(string username, bool userIsOnline)
        {
            // will return user by userName
        }

        public MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        //public  bool ValidateUser(string username, string password)
        //{
        //    var md5Hash = GetMd5Hash(password);

        //    using (var usersContext = new UsersContext())
        //    {
        //        var requiredUser = usersContext.GetUser(username, md5Hash);
        //        return requiredUser != null;
        //    }
        //}

        public static string GetMd5Hash(string value)
        {
            var md5Hasher = MD5.Create();
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}