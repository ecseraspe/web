//-----------------------------------------------------------------------------------------
// <copyright file="HttpClientHelper.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the HttpClientHelper type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Class HttpClientHelper. This class cannot be inherited.
    /// </summary>
    public sealed class HttpClientHelper
    {
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>Object of type T.</returns>
        public static HttpResultData<T> Get<T>(string url)
        {
            HttpResultData<T> result = new HttpResultData<T>();
            try
            {
                YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                var response = GetHttpClient().GetAsync(url).Result;
                YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));
                if (response.IsSuccessStatusCode)
                {
                    result.Items = response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                    if (error != null && error.Count > 0)
                    {
                        if (error.ContainsKey("error_description"))
                        {
                            result.ErrorMessages = error["error_description"];
                        }
                        else
                        {
                            result.ErrorMessages = error.Values.ElementAt(0);
                        }
                    }
                    else
                        result.ErrorMessages = response.StatusCode.ToString();
                    if (string.IsNullOrEmpty(result.ErrorMessages))
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessages = ex.Message;
                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception  {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
            }

            return result;
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="Tin">The type of the in.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public static HttpResultData<Tout> Post<Tin, Tout>(string url, Tin parameter)
        {
            HttpResultData<Tout> result = new HttpResultData<Tout>();
            try
            {
                var response = new HttpResponseMessage();
                if (url == "token")
                {
                    YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                    response = GetHttpClient().PostAsync(url, (dynamic)parameter).Result;
                    YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));
                }
                else
                {
                    YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                    response = GetHttpClient().PostAsJsonAsync(url, parameter).Result;
                    YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));
                }

                if (response.IsSuccessStatusCode)
                {
                    result.Items = response.Content.ReadAsAsync<Tout>().Result;
                }
                else
                {
                    Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                    if (error != null && error.Count > 0)
                    {
                        if (error.ContainsKey("error_description"))
                        {
                            result.ErrorMessages = error["error_description"];
                        }
                        else
                        {
                            result.ErrorMessages = error.Values.ElementAt(0);
                        }
                    }
                    else
                        result.ErrorMessages = response.StatusCode.ToString();

                    if (string.IsNullOrEmpty(result.ErrorMessages))
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessages = ex.Message;
                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception  {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
            }

            return result;
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static HttpResultData<T> Post<T>(string url)
        {
            HttpResultData<T> result = new HttpResultData<T>();
            try
            {
                YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                var response = GetHttpClient().PostAsJsonAsync(url, string.Empty).Result;
                YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));

                if (response.IsSuccessStatusCode)
                {
                    result.Items = response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                    if (error != null && error.Count > 0)
                    {
                        if (error.ContainsKey("error_description"))
                        {
                            result.ErrorMessages = error["error_description"];
                        }
                        else
                        {
                            result.ErrorMessages = error.Values.ElementAt(0);
                        }
                    }
                    else
                        result.ErrorMessages = response.StatusCode.ToString();

                    if (string.IsNullOrEmpty(result.ErrorMessages))
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessages = ex.Message;
                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
            }

            return result;
        }

        /// <summary>
        /// Gets the access token from session.
        /// </summary>
        /// <returns>string</returns>
        public static string GetAccessTokenFromCookie()
        {
            string accessToken = string.Empty;
            try
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    // Get the forms authentication ticket.
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    // Get the custom user data encrypted in the ticket.
                    //string userData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
                    string userData = authTicket.UserData;
                    // Deserialize the json data and set it on the custom principal.
                    var serializer = new JavaScriptSerializer();
                    WebYoufferUserModel userDetail = (WebYoufferUserModel)serializer.Deserialize(userData, typeof(WebYoufferUserModel));
                    accessToken = userDetail.AccessToken;
                    // Set the context user.
                }

            }
            catch (Exception ex)
            {
                YoufferLogger.Log.Info(string.Format("Exception on GetAccessTokenFromCookie is {0}", ex.Message));
            }

            return accessToken;
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="url">The URL.</param>
        /// <returns>Object of type T.</returns>
        public static HttpResultData<T> Delete<T>(string url)
        {
            HttpResultData<T> result = new HttpResultData<T>();
            try
            {
                YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                var response = GetHttpClient().DeleteAsync(url).Result;
                YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));

                if (response.IsSuccessStatusCode)
                {
                    result.Items = response.Content.ReadAsAsync<T>().Result;
                }
                else
                {
                    Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                    if (error != null && error.Count > 0)
                    {
                        if (error.ContainsKey("error_description"))
                        {
                            result.ErrorMessages = error["error_description"];
                        }
                        else
                        {
                            result.ErrorMessages = error.Values.ElementAt(0);
                        }
                    }
                    else
                        result.ErrorMessages = response.StatusCode.ToString();

                    if (string.IsNullOrEmpty(result.ErrorMessages))
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessages = ex.Message;
                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
            }

            return result;
        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="image">The image.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static HttpResultData<T> UploadImage<T>(string url, byte[] image, string fileName)
        {
            HttpResultData<T> result = new HttpResultData<T>();
            using (var client = GetHttpClient())
            {
                using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(new StreamContent(new MemoryStream(image)), "bilddatei", fileName);
                    try
                    {
                        YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                        var response = client.PostAsync(url, content).Result;
                        YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));

                        if (response.IsSuccessStatusCode)
                        {
                            result.Items = response.Content.ReadAsAsync<T>().Result;
                        }
                        else
                        {
                            Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                            if (error != null && error.Count > 0)
                            {
                                if (error.ContainsKey("error_description"))
                                {
                                    result.ErrorMessages = error["error_description"];
                                }
                                else
                                {
                                    result.ErrorMessages = error.Values.ElementAt(0);
                                }
                            }
                            else
                                result.ErrorMessages = response.StatusCode.ToString();

                            if (string.IsNullOrEmpty(result.ErrorMessages))
                            {
                                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                            }
                            else
                            {
                                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result.ErrorMessages = ex.Message;
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
                    }

                    return result;
                }
            }
        }

        public static HttpResultData<T> PostMultiPart<T>(string url, byte[] fileBytes, string fileName, Dictionary<string, string> parameters)
        {
            HttpResultData<T> result = new HttpResultData<T>();
            using (var client = GetHttpClient())
            {
                using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(new StreamContent(new MemoryStream(fileBytes)), fileName.Replace('.', '_'), fileName);

                    foreach (var para in parameters)
                    {
                        content.Add(new StringContent(para.Value), para.Key);
                    }

                    try
                    {
                        YoufferLogger.Log.Info(string.Format("Initiate request \"{0}\" at {1}", url, DateTime.UtcNow));
                        var response = client.PostAsync(url, content).Result;
                        YoufferLogger.Log.Info(string.Format("Request \"{0}\" complete at {1}", url, DateTime.UtcNow));
                        if (response.IsSuccessStatusCode)
                        {
                            result.Items = response.Content.ReadAsAsync<T>().Result;
                        }
                        else
                        {
                            Dictionary<string, string> error = response.Content.ReadAsAsync<Dictionary<string, string>>().Result;
                            if (error != null && error.Count > 0)
                            {
                                if (error.ContainsKey("error_description"))
                                {
                                    result.ErrorMessages = error["error_description"];
                                }
                                else
                                {
                                    result.ErrorMessages = error.Values.ElementAt(0);
                                }
                            }
                            else
                                result.ErrorMessages = response.StatusCode.ToString();

                            if (string.IsNullOrEmpty(result.ErrorMessages))
                            {
                                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is {2}", url, DateTime.UtcNow, response.Content.ReadAsStringAsync().Result));
                            }
                            else
                            {
                                YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1}  is {2}", url, DateTime.UtcNow, result.ErrorMessages));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result.ErrorMessages = ex.Message;
                        YoufferLogger.Log.Info(string.Format("response of \"{0}\" at {1} is exception {2}", url, DateTime.UtcNow, result.ErrorMessages), ex);
                    }

                    return result;
                }
            }
        }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <returns>HttpClient</returns>
        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(AppSettings.ApiBaseUrl) };
            string token = GetAccessTokenFromCookie();
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            }

            return client;
        }



    }
}