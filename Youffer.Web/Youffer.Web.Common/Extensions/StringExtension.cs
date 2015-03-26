//-----------------------------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the StringExtension type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Common.Extensions
{
    /// <summary>
    /// The string extension.
    /// </summary>
    public static class StringExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// Capitalizes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System string.</returns>
        public static string Capitalize(this string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 0)
            {
                return char.ToUpper(value[0]) + value.Substring(1);
            }
            return value;
        }

        /// <summary>
        /// To the unique identifier.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Guid value</returns>
        public static Guid ToGuid(this string value)
        {
            Guid retVal = Guid.Empty;
            if (!string.IsNullOrEmpty(value))
            {
                Guid.TryParse(value, out retVal);
            }

            return retVal;
        }

        /// <summary>
        /// To the json data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>String value.</returns>
        public static string ToJsonData(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                value = (value + string.Empty).Replace("&#39;", "'");
            }

            return value;
        }

        public static int ToAge(this string birthday)
        {
            try
            {
                int age = DateTime.UtcNow.Year - Convert.ToDateTime(string.IsNullOrWhiteSpace(birthday) ? DateTime.UtcNow.ToString() : birthday).Year;
                if (DateTime.UtcNow.Month < Convert.ToDateTime(birthday).Month || (DateTime.UtcNow.Month == Convert.ToDateTime(birthday).Month && DateTime.UtcNow.Day < Convert.ToDateTime(birthday).Day)) age--;
                return age;
            }
            catch
            {
                return -1;
            }
        }

        public static string ToCountryFlag(this string countryName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(countryName))
                {
                    return string.Empty;
                }
                return string.Format(AppSettings.ApiBaseUrl + "Flags/{0}.gif", countryName);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ToMediaUrl(this string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    return string.Empty;
                }

                return string.Format(AppSettings.ApiBaseUrl + GlobalConstants.AttachmentMediaPath + fileName);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetFacebookUrl(this string companyId)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(companyId))
                    return string.Format(AppSettings.ApiBaseUrl + "/usercontent/profileImage/{0}.jpg", companyId);
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the super admin image.
        /// </summary>
        /// <param name="fromUser">From user.</param>
        /// <returns>string type</returns>
        public static string GetSuperAdminImage(this string fromUser)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fromUser))
                    return string.Format(AppSettings.ApiBaseUrl + "/UserContent/ProfileImage/youffersuperadmin_1.jpg");
            }
            catch
            {
                return string.Empty;
            }

            return string.Empty;
        }

        public static string ToPhoneNumber(this string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return string.Empty;
            if (phoneNumber.Split('-').Length == 3) return phoneNumber;
            phoneNumber = phoneNumber.Replace("-", "").Trim();
            if (phoneNumber.Length < 10)
            {
                while (phoneNumber.Length < 10)
                {
                    phoneNumber = string.Concat("0", phoneNumber);
                }
            }
            return string.Format("{0}-{1}-{2}", phoneNumber.Substring(0, 3), phoneNumber.Substring(3, 3), phoneNumber.Substring(6, 4));
        }
        #endregion
    }
}
