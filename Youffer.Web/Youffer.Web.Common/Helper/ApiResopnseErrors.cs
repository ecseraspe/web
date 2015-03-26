//-----------------------------------------------------------------------------------------
// <copyright file="ApiResponseErrors.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>26-Dec-2014</datecreated>
// <summary>
//      Defines the ApiResponseErrors type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Defines type ApiResponseErrors
    /// </summary>
    public class ApiResponseErrors
    {
        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
