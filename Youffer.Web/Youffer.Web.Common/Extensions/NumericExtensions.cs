//-----------------------------------------------------------------------------------------
// <copyright file="NumericExtensions.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the NumericExtensions type
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
    /// Defines types NumericExtensions.
    /// </summary>
    public static class NumericExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// To the int64.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Int64 value</returns>
        public static Int64 ToInt64(this string value)
        {
            Int64 retVal = 0;
            if (!string.IsNullOrEmpty(value))
            {
                Int64.TryParse(value, out retVal);
            }

            return retVal;
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Int32 value</returns>
        public static Int32 ToInt32(this string value)
        {
            return value.ToInt32(0);
        }

        /// <summary>
        /// To the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Int32 value</returns>
        public static Int32 ToInt32(this string value, int defaultValue)
        {
            Int32 retVal = defaultValue;
            if (!string.IsNullOrEmpty(value))
            {
                if (!Int32.TryParse(value, out retVal))
                {
                    retVal = defaultValue;
                }
            }

            return retVal;
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Double value</returns>
        public static double ToDouble(this string value)
        {
            return value.ToDouble(0);
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Double value.</returns>
        public static double ToDouble(this string value, double defaultValue)
        {
            double retVal = defaultValue;
            if (!string.IsNullOrEmpty(value))
            {
                if (!Double.TryParse(value, out retVal))
                {
                    retVal = defaultValue;
                }
            }

            return retVal;
        }

        public static decimal RateThis(this decimal value, bool optimize = false)
        {
            if (optimize)
            {
                value = Math.Round(value, 1);
                int decimalPart = (int)System.Math.Round((value - (int)value) * 10);
                if (decimalPart == 0)
                    return Convert.ToDecimal(value);
                else if (decimalPart > 0 && decimalPart < 3)
                    return Convert.ToDecimal(Math.Truncate(value) + ".0");
                else if (decimalPart >= 3 && decimalPart < 8)
                    return Convert.ToDecimal(Math.Truncate(value) + ".5");
                else
                    return Convert.ToDecimal((Math.Truncate(value) + 1) + ".0");
            }
            else
            {
                return Math.Round(value, 1);
            }
        }
        #endregion
    }
}
