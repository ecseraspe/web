//-----------------------------------------------------------------------------------------
// <copyright file="DateTimeExtension.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the DateTimeExtension type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Extensions
{
    /// <summary>
    /// The date time extension.
    /// </summary>
    public static class DateTimeExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>DateTime value</returns>
        public static DateTime ToDateTime(this string value)
        {
            return value.ToDateTime(new DateTime(1900, 1, 1));
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>DateTime value</returns>
        public static DateTime ToDateTime(this string value, DateTime defaultValue)
        {
            DateTime retVal = defaultValue;
            if (!string.IsNullOrEmpty(value))
            {
                if (!DateTime.TryParse(value, out retVal))
                {
                    retVal = defaultValue;
                }
            }

            return retVal;
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isDay">if set to <c>true</c> [is day].</param>
        /// <param name="isMonth">if set to <c>true</c> [is month].</param>
        /// <returns>String value.</returns>
        public static string ToDateTime(this string value, bool isDay, bool isMonth)
        {
            string retValue;
            DateTime date = value.ToDateTime();

            if (isDay && isMonth)
            {
                retValue = String.Format("{0:dddd, MMMM d, yyyy}", date);
            }
            else if (!isDay && isMonth)
            {
                retValue = String.Format("{0:MMMM, yyyy}", date);
            }
            else
            {
                retValue = String.Format("{0:yyyy}", date);
            }

            return retValue;
        }

        /// <summary>
        /// To the small date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="isDay">if set to <c>true</c> [is day].</param>
        /// <param name="isMonth">if set to <c>true</c> [is month].</param>
        /// <returns>String value.</returns>
        public static string ToSmallDateTime(this string value, bool isDay, bool isMonth)
        {
            string retValue;
            DateTime date = value.ToDateTime();

            if (isDay && isMonth)
            {
                retValue = String.Format("{0:MMM d, yyyy}", date);
            }
            else if (!isDay && isMonth)
            {
                retValue = String.Format("{0:MMM, yyyy}", date);
            }
            else
            {
                retValue = String.Format("{0:yyyy}", date);
            }

            return retValue;
        }

        /// <summary>
        /// To the date only.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>DateTime value</returns>
        public static DateTime ToDateOnly(this string value)
        {
            DateTime convertedDate = new DateTime(1900, 1, 1);
            if (string.IsNullOrEmpty(value))
            {
                return convertedDate;
            }

            try
            {
                value = Convert.ToDateTime(value, CultureInfo.InvariantCulture).ToString("MM'/'dd'/'yyyy");
                string[] datesplit = value.Split('/');
                Int32 month = Convert.ToInt32(datesplit[0]);
                Int32 day = Convert.ToInt32(datesplit[1]);
                Int32 year = Convert.ToInt32(datesplit[2]);
                convertedDate = new DateTime(year, month, day);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return convertedDate;
        }

        /// <summary>
        /// The get date using time zone.
        /// </summary>
        /// <param name="value"> The value. </param>
        /// <param name="timeZone"> The time zone. </param>
        /// <returns> The <see cref="DateTime"/>. </returns>
        public static DateTime GetDateUsingTimeZone(this DateTime value, String timeZone = "")
        {
            var offset = timeZone.ToInt32();
            var newDate = value.AddMinutes(-1 * offset);
            return newDate;
        }

        /// <summary>
        /// The to utc time.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="timeZone">
        /// The time zone.
        /// </param>
        /// <returns>
        /// The <see cref="DateTime"/>.
        /// </returns>
        public static DateTime ToUtcTime(this DateTime value, String timeZone = "")
        {
            var offset = timeZone.ToInt32();
            var newDate = value.AddMinutes(offset);
            return newDate;
        }
        #endregion
    }
}
