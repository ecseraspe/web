//-----------------------------------------------------------------------------------------
// <copyright file="ExternalLoginResultModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>25-Nov-2014</datecreated>
// <summary>
//      Defines the LoginModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines Type LoginModel
    /// </summary>
    public class LoginModel
    {
        public LoginModel()
        {
            this.grant_type = "password";
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [Display(Name = "Company Email")]
        [Required(ErrorMessage = "Company Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the grant_type.
        /// </summary>
        /// <value>
        /// The grant_type.
        /// </value>
        public string grant_type { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
