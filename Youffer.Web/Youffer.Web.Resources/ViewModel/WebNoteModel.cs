//-----------------------------------------------------------------------------------------
// <copyright file="WebNoteModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>20-Nov-2014</datecreated>
// <summary>
//      Defines the WebNoteModel type
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
    /// Defines type WebNoteModel
    /// </summary>
    public class WebNoteModel
    {
        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        /// <value>
        /// The note identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        /// <value>
        /// The company identifier.
        /// </value>
        public string CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the client wish list identifier.
        /// </summary>
        /// <value>
        /// The client wish list identifier.
        /// </value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the note description.
        /// </summary>
        /// <value>
        /// The note description.
        /// </value>
        [Required(ErrorMessage = "Note must have some content.")]
        public string NoteText { get; set; }

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
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
