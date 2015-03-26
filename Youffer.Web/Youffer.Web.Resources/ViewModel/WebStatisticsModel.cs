//-----------------------------------------------------------------------------------------
// <copyright file="WebStatisticsModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Sakshi Tayal</author>
// <datecreated>01-Dec-2014</datecreated>
// <summary>
//      Defines the WebStatisticsModel type
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
    /// Defines type WebStatisticsModel
    /// </summary>
    public class WebStatisticsModel
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }
        /// <summary>
        /// Gets or sets the total clients.
        /// </summary>
        /// <value>
        /// The total clients.
        /// </value>
        public int NumberofClients { get; set; }
        /// <summary>
        /// Gets or sets the clients to make purchase.
        /// </summary>
        /// <value>
        /// The clients to make purchase.
        /// </value>
        public int NumberofPurchases { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
