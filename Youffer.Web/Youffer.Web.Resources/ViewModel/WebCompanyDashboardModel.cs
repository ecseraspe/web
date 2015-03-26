//-----------------------------------------------------------------------------------------
// <copyright file="WebCompanyDashboardModel.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the WebCompanyDashboardModel type
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
    /// Defines type WebCompanyDashboardModel
    /// </summary>
    public class WebCompanyDashboardModel
    {
        /// <summary>
        /// Gets or sets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        public string CompanyLogo { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the type of the main business.
        /// </summary>
        /// <value>
        /// The type of the main business.
        /// </value>
        public string[] SubBusinessType { get; set; }

        /// <summary>
        /// Gets or sets the client wish list.
        /// </summary>
        /// <value>
        /// The client wish list.
        /// </value>
        public List<WebClientWishListModel> ClientWishList { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }
    }
}
