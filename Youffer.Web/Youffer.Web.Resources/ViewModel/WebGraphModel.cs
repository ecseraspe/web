//-----------------------------------------------------------------------------------------
// <copyright file="WebStatisticsModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>02-Dec-2014</datecreated>
// <summary>
//      Defines the WebGraphModel type
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
    /// Defines Type WebGraphModel
    /// </summary>
    public class WebGraphModel
    {
        /// <summary>
        /// Gets or sets the statistic.
        /// </summary>
        /// <value>
        /// The statistic.
        /// </value>
        public List<WebStatisticsModel> Statistic { get; set; }
        /// <summary>
        /// Gets or sets the average rating.
        /// </summary>
        /// <value>
        /// The average rating.
        /// </value>
        public decimal AverageRating { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}

