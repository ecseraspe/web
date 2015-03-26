//-----------------------------------------------------------------------------------------
// <copyright file="WebMessageModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>20-Nov-2014</datecreated>
// <summary>
//      Defines the WebMessageModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Youffer.Resources.ViewModel;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines type WebMessageModel
    /// </summary>
    public class WebMessageModel
    {
        /// <summary>
        /// Note: MessageId = ThreadId, Gets or sets the message identifier.
        /// </summary>
        /// <value>
        /// The message identifier.
        /// </value>
        public long MessageId { get; set; }

        /// <summary>
        /// Gets or sets the client wish list identifier.
        /// </summary>
        /// <value>
        /// The client wish list identifier.
        /// </value>
        public string ClientWishListId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        ///// <summary>
        ///// Gets or sets the type of the message. 1 for Admin 2 for Client
        ///// </summary>
        ///// <value>
        ///// The type of the message.
        ///// </value>
        //public int MessageType { get; set; }

        /// <summary>
        /// Gets or sets the message description.
        /// </summary>
        /// <value>
        /// The message description.
        /// </value>
        [AllowHtml]
        [Required(ErrorMessage = "Message is required.")]
        public string MessageDescription { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is bulk message.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is bulk message; otherwise, <c>false</c>.
        /// </value>
        public bool IsBulkMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is HTML.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is HTML; otherwise, <c>false</c>.
        /// </value>
        public bool IsHtml { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [does contain media].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [does contain media]; otherwise, <c>false</c>.
        /// </value>
        public bool DoesContainMedia { get; set; }

        /// <summary>
        /// Gets or sets from user.
        /// </summary>
        /// <value>
        /// From user.
        /// </value>
        public string FromUser { get; set; }

        /// <summary>
        /// Gets or sets to user.
        /// </summary>
        /// <value>
        /// To user.
        /// </value>
        public string ToUser { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the message media.
        /// </summary>
        /// <value>
        /// The message media.
        /// </value>
        public MessageMediaDto MessageMedia { get; set; }
    }
}
