//-----------------------------------------------------------------------------------------
// <copyright file="WebYoufferUserModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>25-Nov-2014</datecreated>
// <summary>
//      Defines the WebYoufferUserModel type
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
    /// Defines type WebYoufferUserModel
    /// </summary>
    public class WebYoufferUserModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the expiry in.
        /// </summary>
        /// <value>
        /// The expiry in.
        /// </value>
        [JsonProperty("ExpiresIn")]
        public string ExpiryIn { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [JsonProperty("Issued")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the expire time.
        /// </summary>
        /// <value>
        /// The expire time.
        /// </value>
        [JsonProperty("Expires")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}