//-----------------------------------------------------------------------------------------
// <copyright file="WebExternalLoginResultModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>25-Nov-2014</datecreated>
// <summary>
//      Defines the WebExternalLoginResultModel type
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
    /// Defines type WebExternalLoginResultModel
    /// </summary>
    public class WebExternalLoginResultModel
    {
        /// <summary>
        /// Gets or sets the external access token.
        /// </summary>
        /// <value>
        /// The external access token.
        /// </value>
        public string ExternalAccessToken { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebExternalLoginResultModel"/> is haslocalaccount.
        /// </summary>
        /// <value>
        ///   <c>true</c> if haslocalaccount; otherwise, <c>false</c>.
        /// </value>
        public bool HasLocalAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the external user.
        /// </summary>
        /// <value>
        /// The name of the external user.
        /// </value>
        public string ExternalUserName { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
