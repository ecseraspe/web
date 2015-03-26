//-----------------------------------------------------------------------------------------
// <copyright file="WebBusinessTypesModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the WebBusinessTypesModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines Type WebBusinessTypesModel
    /// </summary>
    public class WebBusinessTypesModel
    {
        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>
        /// The type of the business.
        /// </value>
        [JsonProperty("Key")]
        public string BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the business type identifier.
        /// </summary>
        /// <value>
        /// The business type identifier.
        /// </value>
        [JsonProperty("Value")]
        public string BusinessTypeId { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
