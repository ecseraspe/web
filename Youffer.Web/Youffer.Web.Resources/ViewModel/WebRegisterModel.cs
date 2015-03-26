//-----------------------------------------------------------------------------------------
// <copyright file="WebRegisterModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the WebRegisterModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Enum;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines Type WebRegisterModel
    /// </summary>
    public class WebRegisterModel
    {
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company name is required.")]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the type of the business.
        /// </summary>
        /// <value>
        /// The type of the business.
        /// </value>
        [Display(Name = "Main Business Type")]
        public List<WebBusinessTypesModel> BusinessType { get; set; }

        /// <summary>
        /// Gets or sets the type of the selected business.
        /// </summary>
        /// <value>
        /// The type of the selected business.
        /// </value>
        [Required(ErrorMessage = "Business Type is required.")]
        public string SelectedBusinessType { get; set; }

        /// <summary>
        /// Gets or sets the type of the sub business.
        /// </summary>
        /// <value>
        /// The type of the sub business.
        /// </value>
        public string SubBusinessType { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{8,11}", ErrorMessage = "Invalid phone number")]
        [Required(ErrorMessage="Phone number is required.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the country code list.
        /// </summary>
        /// <value>
        /// The country code list.
        /// </value>
        public List<CountryDummy> CountryCodeList { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebRegisterModel"/> is terms.
        /// </summary>
        /// <value>
        ///   <c>true</c> if terms; otherwise, <c>false</c>.
        /// </value>
        [Display(Name = "Terms and Conditions")]
        [Compare("Terms", ErrorMessage = "You must accept Terms and Conditions")]
        public bool Terms { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public int Role { get; set; }

        /// <summary>
        /// Gets or sets the timezone.
        /// </summary>
        /// <value>
        /// The timezone.
        /// </value>
        public string Timezone { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the type of the os.
        /// </summary>
        /// <value>
        /// The type of the os.
        /// </value>
        public OSType OSType { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
