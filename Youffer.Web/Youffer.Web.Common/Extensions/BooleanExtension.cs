//-----------------------------------------------------------------------------------------
// <copyright file="BooleanExtension.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the BooleanExtension type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Extensions
{
    /// <summary>
    /// The boolean extension.
    /// </summary>
    public static class BooleanExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// To the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBoolean(this string value)
        {
            return value.ToBoolean(false);
        }

        /// <summary>
        /// To the boolean.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ToBoolean(this string value, bool defaultValue)
        {
            bool retVal = defaultValue;
            if (!string.IsNullOrEmpty(value))
            {
                if (!bool.TryParse(value, out retVal))
                {
                    retVal = value == "1";
                }
            }

            return retVal;
        }

        /////// <summary>
        /////// Determines whether [is valid email] [the specified input email].
        /////// </summary>
        /////// <param name="inputEmail"> The input email. </param>
        /////// <returns> <c>true</c> if [is valid email] [the specified input email]; otherwise, <c>false</c>. </returns>
        ////public static bool IsValidEmail(string inputEmail)
        ////{
        ////    if (inputEmail != string.Empty)
        ////    {
        ////        const string StrRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}"
        ////                                + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\"
        ////                                + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        ////        var re = new Regex(StrRegex);
        ////        return re.IsMatch(inputEmail);
        ////    }

        ////    return false;
        ////}

        #endregion
    }
}
