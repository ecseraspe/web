//-----------------------------------------------------------------------------------------
// <copyright file="UserService.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the UserService type
// </summary>
//-----------------------------------------------------------------------------------------    

namespace Youffer.Web.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Youffer.Resources.CRMModel;
    using Youffer.Resources.Enum;
    using Youffer.Resources.Models;
    using Youffer.Resources.ViewModel;
    using Youffer.Web.Common;
    using Youffer.Web.Common.Helper;
    using Youffer.Web.Common.Service;
    using Youffer.Web.Resources.ViewModel;

    /// <summary>
    /// Defines type UserService
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="registerModel">The register model.</param>
        /// <returns>WebRegisterModel Model</returns>
        public WebRegisterModel RegisterUser(WebRegisterModel registerModel)
        {
            WebRegisterModel registerResult = new WebRegisterModel();
            try
            {
                registerModel.SubBusinessType = registerModel.SelectedBusinessType;
                registerModel.Role = 3;
                registerModel.OSType = OSType.Web;
                UserModel model = Mapper.Map<WebRegisterModel, UserModel>(registerModel);
                HttpResultData<StatusMessage> res = HttpClientHelper.Post<UserModel, StatusMessage>(ApiHelper.RegisterUserFromFormApi, model);
                registerResult = registerModel;
                if (string.IsNullOrEmpty(res.ErrorMessages))
                {
                    if (!res.Items.IsSuccess)
                    {
                        registerResult.ErrorMessage = "Registration fail";
                    }
                }
                else
                {
                    registerResult.ErrorMessage = res.ErrorMessages;
                }

            }
            catch (Exception ex)
            {
                registerResult.ErrorMessage = ex.Message;
                Logger.LogException(ex);
            }

            return registerResult;
        }

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="externalLoginResult">The external login result.</param>
        /// <returns>WebYoufferUserModel Model</returns>
        public WebYoufferUserModel ExternalLogin(WebExternalLoginResultModel externalLoginResult)
        {
            WebYoufferUserModel youfferUser = new WebYoufferUserModel();
            try
            {
                var url = string.Format(ApiHelper.ExternalLoginApi, externalLoginResult.Provider, externalLoginResult.ExternalAccessToken);
                HttpResultData<WebYoufferUserModel> accessToken = HttpClientHelper.Get<WebYoufferUserModel>(url);
                if (accessToken.ErrorMessages == null)
                {
                    youfferUser = accessToken.Items;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return youfferUser;
        }

        /// <summary>
        /// Forms the login.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// WebYoufferUserModel Model
        /// </returns>
        public WebYoufferUserModel FormLogin(string email, string password)
        {
            WebYoufferUserModel youfferUser = new WebYoufferUserModel();
            string requestParameter = "grant_type=password&username=" + email + "&password=" + password;
            var content = new StringContent(requestParameter);
            HttpResultData<WebFormLoginResultModel> accessToken = HttpClientHelper.Post<StringContent, WebFormLoginResultModel>(ApiHelper.FormLoginApi, content);

            if (accessToken.ErrorMessages == null)
            {
                youfferUser = Mapper.Map<WebFormLoginResultModel, WebYoufferUserModel>(accessToken.Items);
            }
            else
            {
                youfferUser.ErrorMessage = accessToken.ErrorMessages;
            }

            return youfferUser;
        }

        /// <summary>
        /// Forgots the password request.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>StatusMessage</returns>
        public StatusMessage ForgotPasswordRequest(string email)
        {
            var url = string.Format(ApiHelper.ForgotPasswordRequestApi, email);
            HttpResultData<StatusMessage> result = HttpClientHelper.Get<StatusMessage>(url);
            StatusMessage returnResult = new StatusMessage();
            if (string.IsNullOrEmpty(result.ErrorMessages) && result.Items != null)
            {
                returnResult = result.Items;
            }
            else
            {
                returnResult.ErrorMessage = result.ErrorMessages;
            }

            return returnResult;
        }

        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>StatusMessage</returns>
        public StatusMessage UpdatePassword(ForgotPassword model)
        {
            var url = ApiHelper.UpdateForgotPasswordApi;
            HttpResultData<StatusMessage> result = HttpClientHelper.Post<ForgotPassword, StatusMessage>(url, model);
            StatusMessage returnResult = new StatusMessage();
            if (string.IsNullOrEmpty(result.ErrorMessages) && result.Items != null)
            {
                returnResult = result.Items;
            }
            else
            {
                returnResult.ErrorMessage = result.ErrorMessages;
            }
            return returnResult;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>StatusMessage</returns>
        public StatusMessage ChangePassword(ChangePasswordModel model)
        {
            var url = ApiHelper.ChangePasswordApi;
            HttpResultData<StatusMessage> result = HttpClientHelper.Post<ChangePasswordModel, StatusMessage>(url, model);
            StatusMessage returnResult = new StatusMessage();
            if (string.IsNullOrEmpty(result.ErrorMessages) && result.Items != null)
            {
                returnResult = result.Items;
            }
            else
            {
                returnResult.ErrorMessage = result.ErrorMessages;
            }
            return returnResult;
        }
    }
}
