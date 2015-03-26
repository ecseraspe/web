//-----------------------------------------------------------------------------------------
// <copyright file="WebClientModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the WebClientModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Enum;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines type WebClientModel
    /// </summary>
    public class WebClientModel
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The Contact identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the availability.
        /// </summary>
        /// <value>
        /// The availability.
        /// </value>
        public Availability Availability { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the interests list.
        /// </summary>
        /// <value>
        /// The interests list.
        /// </value>
        public List<WebBusinessTypesModel> InterestsList { get; set; }

        /// <summary>
        /// Gets or sets the interests.
        /// </summary>
        /// <value>
        /// The interests.
        /// </value>
        public string[] Interests { get; set; }

        /// <summary>
        /// Gets or sets the sub interest.
        /// </summary>
        /// <value>
        /// The sub interest.
        /// </value>
        public string[] SubInterest { get; set; }

        /// <summary>
        /// Gets or sets the country list.
        /// </summary>
        /// <value>
        /// The country list.
        /// </value>
        public List<WebCountryModel> CountryList { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public int Country { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        /// <value>
        /// The name of the country.
        /// </value>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the country flag.
        /// </summary>
        /// <value>
        /// The name of the country flag.
        /// </value>
        public string Flag { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is available; otherwise, <c>false</c>.
        /// </value>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the ranking.
        /// </summary>
        /// <value>
        /// The ranking.
        /// </value>
        public Decimal Ranking { get; set; }

        /// <summary>
        /// Gets or sets the wish list identifier.
        /// </summary>
        /// <value>
        /// The wish list identifier.
        /// </value>
        public string WishListId { get; set; }

        /// <summary>
        /// Gets or sets the available from.
        /// </summary>
        /// <value>
        /// The available from.
        /// </value>
        public string AvailableFrom { get; set; }

        /// <summary>
        /// Gets or sets the available to.
        /// </summary>
        /// <value>
        /// The available to.
        /// </value>
        public string AvailableTo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can call.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can call; otherwise, <c>false</c>.
        /// </value>
        public bool CanCall { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is online.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is online; otherwise, <c>false</c>.
        /// </value>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [mark purchased].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [mark purchased]; otherwise, <c>false</c>.
        /// </value>
        public bool MarkPurchased { get; set; }
    }
}

