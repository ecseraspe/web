//-----------------------------------------------------------------------------------------
// <copyright file="WebClientReviewModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>20-Nov-2014</datecreated>
// <summary>
//      Defines the WebClientReviewModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines type WebClientReviewModel
    /// </summary>
    public class WebClientReviewModel
    {
        /// <summary>
        /// Gets or sets the review identifier.
        /// </summary>
        /// <value>
        /// The review identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the client wish list identifier.
        /// </summary>
        /// <value>
        /// The client wish list identifier.
        /// </value>
        public string ClientWishListId { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified by.
        /// </summary>
        /// <value>
        /// The modified by.
        /// </value>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the modified on.
        /// </summary>
        /// <value>
        /// The modified on.
        /// </value>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public Decimal Rating { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the Interest Name
        /// </summary>
        public string InterestName { get; set; }

        /// <summary>
        /// Gets or sets the Company Image Url
        /// </summary>
        public string CompanyImageUrl { get; set; }
    }
}
