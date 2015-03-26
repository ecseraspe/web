//-----------------------------------------------------------------------------------------
// <copyright file="WebClientWishListModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the WebClientWishListModel type
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
    /// Defines type WebClientWishListModel
    /// </summary>
    public class WebClientWishListModel
    {
        public WebClientWishListModel()
        {
            this.Review = new WebClientReviewModel();
        }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public string CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the wish list identifier.
        /// </summary>
        /// <value>
        /// The wish list identifier.
        /// </value>
        public string WishListId { get; set; }

        /// <summary>
        /// Gets or sets the interest.
        /// </summary>
        /// <value>
        /// The interest.
        /// </value>
        public string[] Interest { get; set; }

        /// <summary>
        /// Gets or sets the sub interest.
        /// </summary>
        /// <value>
        /// The sub interest.
        /// </value>
        public string[] SubInterest { get; set; }

        /// <summary>
        /// Gets or sets the purchased interest.
        /// </summary>
        /// <value>
        /// The purchased interest.
        /// </value>
        public string PurchasedInterest { get; set; }

        /// <summary>
        /// Gets or sets the ranking.
        /// </summary>
        /// <value>
        /// The ranking.
        /// </value>
        public Decimal Ranking { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public WebClientModel Client { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        public WebRatingModel Rating { get; set; }

        /// <summary>
        /// Gets or sets the review list.
        /// </summary>
        /// <value>
        /// The review list.
        /// </value>
        public List<WebClientReviewModel> ReviewList { get; set; }

        /// <summary>
        /// Gets or sets the note list.
        /// </summary>
        /// <value>
        /// The note list.
        /// </value>
        public List<WebNoteModel> NoteList { get; set; }

        /// <summary>
        /// Gets or sets the message list.
        /// </summary>
        /// <value>
        /// The message list.
        /// </value>
        public List<WebMessageModel> MessageList { get; set; }

        /// <summary>
        /// Gets or sets the review.
        /// </summary>
        /// <value>
        /// The review.
        /// </value>
        public WebClientReviewModel Review { get; set; }
        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>
        /// The note.
        /// </value>
        public WebNoteModel Note { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public WebMessageModel Message { get; set; }

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
