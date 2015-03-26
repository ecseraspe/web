//-----------------------------------------------------------------------------------------
// <copyright file="ValidationExtension.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the ValidationExtension type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Common.Extensions
{
    public static class ValidationExtension
    {
        #region Public Methods and Operators
        /// <summary>
        /// Determines whether [is valid email] [the specified input email].
        /// </summary>
        /// <param name="val">
        /// The input email.
        /// </param>
        /// <returns>
        /// <c>true</c> if [is valid email] [the specified input email]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmail(this string val)
        {
            if (val == string.Empty)
            {
                return false;
            }

            try
            {
                const string RegEx = GlobalConstants.EmailRegEx;

                return Regex.IsMatch(val, RegEx, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is valid URL] [the specified value].
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        /// <c>true</c> if [is valid URL] [the specified input URL]; otherwise, <c>false</c>
        /// </returns>
        public static bool IsValidURL(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }

            try
            {
                const string RegEx = GlobalConstants.UrlRegEx;
                return Regex.IsMatch(val, RegEx, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return false;
            }
        }

        #endregion
    }
}
