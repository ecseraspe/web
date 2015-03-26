//-----------------------------------------------------------------------------------------
// <copyright file="WebCompanyPaymentModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>26-Nov-2014</datecreated>
// <summary>
//      Defines the WebCompanyProfileModel type
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
    /// Defines Type WebCompanyPaymentModel 
    /// </summary>
    public class WebCompanyPaymentModel
    {
        /// <summary>
        /// Gets or sets the payment mode.
        /// </summary>
        /// <value>
        /// The payment mode.
        /// </value>
        public string SelectedPaymentMode { get; set; }
        /// <summary>
        /// Gets or sets the paypal account.
        /// </summary>
        /// <value>
        /// The paypal account.
        /// </value>
        public string PaypalAccount { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is paypal.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is paypal; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaypal { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is card.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is card; otherwise, <c>false</c>.
        /// </value>
        public bool IsCard { get; set; }
        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        /// <value>
        /// The card number.
        /// </value>
        public string CardNumber { get; set;}
        /// <summary>
        /// Gets or sets the expiry month.
        /// </summary>
        /// <value>
        /// The expiry month.
        /// </value>
        public int ExpiryMonth { get; set; }
        /// <summary>
        /// Gets or sets the expiry year.
        /// </summary>
        /// <value>
        /// The expiry year.
        /// </value>
        public int ExpiryYear { get; set; }
        /// <summary>
        /// Gets or sets the CVV.
        /// </summary>
        /// <value>
        /// The CVV.
        /// </value>
        public string Cvv { get; set; }
    }
}
