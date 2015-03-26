//-----------------------------------------------------------------------------------------
// <copyright file="WebRatingModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>20-Nov-2014</datecreated>
// <summary>
//      Defines the WebRatingModel type
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
    /// Defines type WebRatingModel
    /// </summary>
    public class WebRatingModel
    {
        /// <summary>
        /// Gets or sets the rating identifier.
        /// </summary>
        /// <value>
        /// The rating identifier.
        /// </value>
        public long RatingId { get; set; }

        /// <summary>
        /// Gets or sets the client wish list identifier.
        /// </summary>
        /// <value>
        /// The client wish list identifier.
        /// </value>
        public string ClientWishListId { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [Required(ErrorMessage = "Review Text is required")]
        public Decimal Rating { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
