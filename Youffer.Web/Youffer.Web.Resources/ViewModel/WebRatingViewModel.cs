//-----------------------------------------------------------------------------------------
// <copyright file="WebClientWishListModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>29-Jan-2015</datecreated>
// <summary>
//      Defines the WebClientWishListModel type
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
    /// Defines type WebRatingViewModel
    /// </summary>
    public class WebRatingViewModel
    {
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public double Rating { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebRatingViewModel"/> is disabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if disabled; otherwise, <c>false</c>.
        /// </value>
        public bool Disabled { get; set; }
        /// <summary>
        /// Gets or sets the name of the rating class.
        /// </summary>
        /// <value>
        /// The name of the rating class.
        /// </value>
        public string RatingClassName { get; set; }
        /// <summary>
        /// Gets or sets the callback method.
        /// </summary>
        /// <value>
        /// The callback method.
        /// </value>
        public string CallbackMethod { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show rating].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show rating]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowRating { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
