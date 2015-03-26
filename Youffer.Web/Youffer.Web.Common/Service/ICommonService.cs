//-----------------------------------------------------------------------------------------
// <copyright file="ICommonService.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the ICommonService type
// </summary>
//-----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using Youffer.Web.Resources.ViewModel;
using Youffer.Web.Common.Dummy;
using Youffer.Resources.ViewModel;
using Youffer.Resources.Models;

namespace Youffer.Web.Common.Service
{
    /// <summary>
    /// Defines type ICommonService
    /// </summary>
    public interface ICommonService
    {
        /// <summary>
        /// Gets all business types.
        /// </summary>
        /// <returns>List of WebBusinessTypesModel</returns>
        List<WebBusinessTypesModel> GetAllBusinessTypes();

        /// <summary>
        /// Gets all sub interest.
        /// </summary>
        /// <param name="interest">The interest.</param>
        /// <returns>
        /// List of WebBusinessTypesModel
        /// </returns>
        List<WebBusinessTypesModel> GetAllSubInterest(string interest);

        /// <summary>
        /// Gets the home page client.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <returns></returns>
        List<WebClientWishListModel> GetHomePageClient(string searchBy = "", int lastPageId = 0, int numberOfRecords = 8);

        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>List of WebCountryModel</returns>
        List<WebCountryModel> GetAllCountry();

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool SendMail(MailMessage model);
        
        /// <summary>
        /// Gets all country calling code.
        /// </summary>
        /// <returns></returns>
        List<CountryDummy> GetAllCountryCallingCode();

        /// <summary>
        /// Contacts the us.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        bool ContactUs(ContactUsDto model);

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns>StateModel</returns>
        List<StateModel> GetStates(string country = "");
    }
}
