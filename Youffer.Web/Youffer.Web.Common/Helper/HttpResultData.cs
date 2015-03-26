//-----------------------------------------------------------------------------------------
// <copyright file="HttpResultData.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the HttpResultData type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Defines generic HttpResultData for all api calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HttpResultData<T>
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public T Items { get; set; }

        /// <summary>
        /// Gets or sets the error messages.
        /// </summary>
        /// <value>
        /// The error messages.
        /// </value>
        public string ErrorMessages { get; set; }

    }
}
