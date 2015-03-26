//-----------------------------------------------------------------------------------------
// <copyright file="WebCompanyProfileModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the WebCompanyProfileModel type
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
    /// Defines type WebCompanyProfileModel
    /// </summary>
    public class WebCompanyProfileModel
    {
        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public string CompanyId { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the facebook URL.
        /// </summary>
        /// <value>
        /// The facebook URL.
        /// </value>
        [Url(ErrorMessage = "Please enter a valid facebook url.")]
        public string FacebookUrl { get; set; }

        /// <summary>
        /// Gets or sets the website URL.
        /// </summary>
        /// <value>
        /// The website URL.
        /// </value>
        [Url(ErrorMessage = "Please enter a valid website url.")]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Gets or sets the business types.
        /// </summary>
        /// <value>
        /// The business types.
        /// </value> 
        public List<WebBusinessTypesModel> BusinessTypes { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{8,11}", ErrorMessage = "Please enter a valid phone number.")]
        [Required(ErrorMessage="Phone number is required.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the payment.
        /// </summary>
        /// <value>
        /// The payment.
        /// </value>

        public WebCompanyPaymentModel Payment { get; set; }
        /// <summary>
        /// Gets or sets the selected business types.
        /// </summary>
        /// <value>
        /// The selected business types Id.
        /// </value>
        //[Required(ErrorMessage = "Business Type is required.")]
        public string SelectedBusinessTypeId { get; set; }

        /// <summary>
        /// Gets or sets the selected main business types.
        /// </summary>
        /// <value>
        /// The selected main business types.
        /// </value>
        public string[] SelectedMainBusinessTypes { get; set; }

        /// <summary>
        /// Gets or sets the selected sub business types.
        /// </summary>
        /// <value>
        /// The selected sub business types.
        /// </value>
        public string[] SelectedSubBusinessTypes { get; set; }

        /// <summary>
        /// Gets or sets the updated image URL.
        /// </summary>
        /// <value>
        /// The updated image URL.
        /// </value>
        public string UpdatedImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the countrie list.
        /// </summary>
        /// <value>
        /// The countrie list.
        /// </value>
        public List<WebCountryModel> CountryList { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

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
    }
}
