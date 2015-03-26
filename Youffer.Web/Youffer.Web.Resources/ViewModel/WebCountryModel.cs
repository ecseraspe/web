//-----------------------------------------------------------------------------------------
// <copyright file="WebCountryModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the WebCountryModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines type WebCountryModel
    /// </summary>
    public class WebCountryModel
    {
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName { get; set; }
        /// <summary>
        /// Gets or sets the long name of the country.
        /// </summary>
        /// <value>The long name of the country.</value>
        public string LongCountryName { get; set; }

        /// <summary>
        /// Gets or sets the is o2.
        /// </summary>
        /// <value>The is o2.</value>
        public string ISO2 { get; set; }

        /// <summary>
        /// Gets or sets the is o3.
        /// </summary>
        /// <value>The is o3.</value>
        public string ISO3 { get; set; }

        /// <summary>
        /// Gets or sets the number code.
        /// </summary>
        /// <value>The number code.</value>
        public string NumCode { get; set; }

        /// <summary>
        /// Gets or sets the calling code.
        /// </summary>
        /// <value>The calling code.</value>
        public string CallingCode { get; set; }

        /// <summary>
        /// Gets or sets the CCTLD.
        /// </summary>
        /// <value>The CCTLD.</value>
        public string CCTLD { get; set; }

        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        /// <value>The flag identifier.</value>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
