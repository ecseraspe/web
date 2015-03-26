//-----------------------------------------------------------------------------------------
// <copyright file="IRegisterService.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the IRegisterService type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Models;
using Youffer.Resources.ViewModel;
using Youffer.Web.Resources.ViewModel;
namespace Youffer.Web.Common.Service
{
    /// <summary>
    /// Defines type IRegisterService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="registerModel">The register model.</param>
        /// <returns>WebRegisterModel</returns>
        WebRegisterModel RegisterUser(WebRegisterModel registerModel);

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="externalLoginResult">The external login result.</param>
        /// <returns>WebYoufferUserModel</returns>
        WebYoufferUserModel ExternalLogin(WebExternalLoginResultModel externalLoginResult);

        /// <summary>
        /// Forms the login.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        WebYoufferUserModel FormLogin(string email, string password);

        /// <summary>
        /// Forgots the password request.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>StatusMessage</returns>
        StatusMessage ForgotPasswordRequest(string email);

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>StatusMessage</returns>
        StatusMessage UpdatePassword(ForgotPassword model);

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>StatusMessage</returns>
        StatusMessage ChangePassword(ChangePasswordModel model);
    }
}
