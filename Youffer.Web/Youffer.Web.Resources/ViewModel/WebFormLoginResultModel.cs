//-----------------------------------------------------------------------------------------
// <copyright file="WebFormLoginResultModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>25-Nov-2014</datecreated>
// <summary>
//      Defines the WebFormLoginResultModel type
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
    ///  Defines the WebFormLoginResultModel type
    /// </summary>
    public class WebFormLoginResultModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [JsonProperty("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }//

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        /// <value>
        /// The type of the token.
        /// </value>
        [JsonProperty("token_type")]
        public string TokenType { get; set; } //

        /// <summary>
        /// Gets or sets the expiry in.
        /// </summary>
        /// <value>
        /// The expiry in.
        /// </value>
        [JsonProperty("expires_in")]
        public string ExpiryIn { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        [JsonProperty(".issued")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the expiry in.
        /// </summary>
        /// <value>
        /// The expiry in.
        /// </value>
        [JsonProperty(".expires")]
        public string ExpireTime { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}