//-----------------------------------------------------------------------------------------
// <copyright file="WebClientSearchPanelModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>21-Nov-2014</datecreated>
// <summary>
//      Defines the WebClientSearchPanelModel type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace Youffer.Web.Resources.ViewModel
{
    /// <summary>
    /// Defines type WebClientSearchPanelModel
    /// </summary>
    public class WebClientSearchPanelModel
    {
        /// <summary>
        /// Gets or sets the name of the interest.
        /// </summary>
        /// <value>
        /// The name of the interest.
        /// </value>
        [Required(ErrorMessage = "Please select your business type.")]
        public string InterestName { get; set; }

        /// <summary>
        /// Gets or sets the name of the sub interest.
        /// </summary>
        /// <value>
        /// The name of the sub interest.
        /// </value>
        public string SubInterestName { get; set; }

        /// <summary>
        /// Gets or sets the age from.
        /// </summary>
        /// <value>
        /// The age from.
        /// </value>
        public int? AgeFrom { get; set; }

        /// <summary>
        /// Gets or sets the age to.
        /// </summary>
        /// <value>
        /// The age to.
        /// </value>
        [GreaterThanOrEqualTo("AgeFrom", ErrorMessage = "\"Age To\" should be greater than or equal to \"Age From\"")]
        public int? AgeTo { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [only active client].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [only active client]; otherwise, <c>false</c>.
        /// </value>
        public bool OnlyActiveClient { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [only reviewed client].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [only reviewed client]; otherwise, <c>false</c>.
        /// </value>
        public bool OnlyReviewedClient { get; set; }

        /// <summary>
        /// Gets or sets my client search.
        /// </summary>
        /// <value>
        /// My client search.
        /// </value>
        public string MyClientSearch { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        /// <value>
        /// The sort direction.
        /// </value>
        public int SortDirection { get; set; }

        /// <summary>
        /// Gets or sets the sort by column.
        /// </summary>
        /// <value>
        /// The sort by column.
        /// </value>
        public int SortByColumn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is reviewed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is reviewed; otherwise, <c>false</c>.
        /// </value>
        public bool IsReviewed { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the last page identifier.
        /// </summary>
        /// <value>
        /// The last page identifier.
        /// </value>
        public int LastPageId { get; set; }

        /// <summary>
        /// Gets or sets the fetch count.
        /// </summary>
        /// <value>
        /// The fetch count.
        /// </value>
        public int FetchCount { set; get; }
    }
}
