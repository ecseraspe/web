//-----------------------------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the AppSettings type
// </summary>
//-----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Defines type AppSettings.
    /// </summary>
    public sealed class AppSettings
    {
        /// <summary>
        /// Base url for Web API
        /// </summary>
        /// <value>The API base URL.</value>
        public static string ApiBaseUrl
        {
            get
            {
                return Get<String>(WebConfigKeyConstant.ApiBaseUrl);
            }
        }

        /// <summary>
        /// Gets the specified item key.
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="itemKey">The item key.</param>
        /// <param name="language">The language.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Property value</returns>
        public static T Get<T>(string itemKey, string language, T defaultValue)
        {
            var ret = Get(itemKey, defaultValue);
            ret = Get(itemKey + "_" + language, ret);
            return ret;
        }

        /// <summary>
        /// Gets the specified item key.
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="itemKey">The item key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Property value</returns>
        public static T Get<T>(string itemKey, T defaultValue)
        {
            T data;
            try
            {
                String setting = ConfigurationManager.AppSettings[itemKey];
                if (setting == null)
                {
                    data = defaultValue;
                }
                else
                {
                    data = (T)Convert.ChangeType(setting, typeof(T));
                }
            }
            catch
            {
                data = defaultValue;
            }

            return data;
        }

        /// <summary>
        /// Gets the specified item key.
        /// </summary>
        /// <typeparam name="T">Type of property</typeparam>
        /// <param name="itemKey">The item key.</param>
        /// <returns>Property value</returns>
        public static T Get<T>(string itemKey)
        {
            T data;
            try
            {
                String setting = ConfigurationManager.AppSettings[itemKey];
                if (setting == null)
                {
                    data = default(T);
                }
                else
                {
                    data = (T)Convert.ChangeType(setting, typeof(T));
                }
            }
            catch
            {
                data = default(T);
            }

            return data;
        }
    }
}