//-----------------------------------------------------------------------------------------
// <copyright file="CookieHelper.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the CookieHelper type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Defines type CookieHelper
    /// </summary>
    public static class CookieHelper
    {

        /// <summary>
        /// The set cookie.
        /// </summary>
        /// <param name="key"> The key.</param>
        /// <param name="value"> The value. </param>
        /// <param name="expires"> The expires. </param>
        public static void SetCookie(string key, string value, TimeSpan expires)
        {
            ////HttpCookie encodedCookie = HttpSecureCookie.Encode(new HttpCookie(key, value));

            HttpCookie encodedCookie = new HttpCookie(key, value);
            encodedCookie.Path = "/";
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.Add(expires);
                cookieOld.Value = encodedCookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                encodedCookie.Expires = DateTime.Now.Add(expires);
                HttpContext.Current.Response.Cookies.Add(encodedCookie);
            }
        }

        /// <summary>
        /// The get cookie.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns> The <see cref="string"/>. </returns>
        public static string GetCookie(string key)
        {
            string value = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

            if (cookie != null)
            {
                // For security purpose, we need to encrypt the value.
                //////HttpCookie decodedCookie = HttpSecureCookie.Decode(cookie);
                HttpCookie decodedCookie = cookie;
                value = decodedCookie.Value;
            }

            return value;
        }
    }
}
