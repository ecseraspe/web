//-----------------------------------------------------------------------------------------
// <copyright file="IClientService.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>21-Nov-2014</datecreated>
// <summary>
//      Defines the IClientService type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.ViewModel;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Common.Service
{
    /// <summary>
    /// Defines type IClientService
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>List of WebClientWishListModel</returns>
        List<WebClientWishListModel> GetAllClients(int lastPageId = 0, int numberOfRecords = 10, int sortBy = 0, int direction = 1);

        /// <summary>
        /// Gets the client profile.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>WebClientModel</returns>
        WebClientModel GetClientProfile(string ClientId);

        /// <summary>
        /// Searches the client.
        /// </summary>
        /// <param name="searchModel">The search model.</param>
        /// <returns>List of WebClientWishListModel</returns>
        List<WebClientWishListModel> SearchClient(WebClientSearchPanelModel searchModel);

        /// <summary>
        /// Gets the client profile and review.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>WebClientWishListModel</returns>
        WebClientWishListModel GetClientProfileAndReview(string wishListId, string interest = "");

        /// <summary>
        /// Buys the client.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>true if purchased successfully</returns>
        bool BuyClient(string WishListId, string interest);

        /// <summary>
        /// Submits the review form.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>True or False</returns>
        bool SubmitReviewForm(WebClientWishListModel model);

        /// <summary>
        /// Gets the note history.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <returns>
        /// WebClientWishListModel
        /// </returns>
        WebClientWishListModel GetNoteHistory(string wishListId, long lastPageId = 0, int numberOfRecords = 10);

        /// <summary>
        /// Submits the note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>WebNoteModel Model</returns>
        WebNoteModel SubmitNote(WebNoteModel model);

        /// <summary>
        /// Submits the message.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>WebMessageModel</returns>
        WebMessageModel SubmitMessage(WebClientWishListModel model);

        /// <summary>
        /// Clients the message history.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="NumberOfRecords">The number of records.</param>
        /// <returns>
        /// WebClientWishListModel
        /// </returns>
        WebClientWishListModel GetClientMessageHistory(string wishListId, int lastPageId = 0, int NumberOfRecords = 100);

        /// <summary>
        /// Deletes the client.
        /// </summary>
        /// <param name="WishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        bool DeleteClient(string WishListId, string interest);

        /// <summary>
        /// Clients the note reviewed.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// List of WebClientWishListModel
        /// </returns>
        List<WebClientWishListModel> ClientsNotReviewed(int lastPageId = 0, int numberOfRecords = 10, int sortBy = 0, int direction = 1);

        /// <summary>
        /// Gets all message.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by. Note: sortBy="" mean default sort on createdon, otherwise pass columnName</param>
        /// <param name="direction">The sort direction. asc and desc</param>
        /// <returns>
        /// List of WebMessageModel
        /// </returns>
        List<WebMessageModel> GetAllMessage(int lastPageId = 0, int numberOfRecords = 100, string sortBy = "", string direction = "desc");
        
        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>
        /// bool
        /// </returns>
        bool DeleteMessage(long messageId);

        /// <summary>
        /// Gets the company profile.
        /// </summary>
        /// <returns>WebCompanyProfileModel</returns>
        WebCompanyProfileModel GetCompanyProfile();

        /// <summary>
        /// Submits the company profile.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>bool</returns>
        bool SubmitCompanyProfile(WebCompanyProfileModel model);

        /// <summary>
        /// Completes the registration.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>bool</returns>
        bool CompleteRegistration(WebCompanyProfileModel model);

        /// <summary>
        /// Gets the statistics detail.
        /// </summary>
        /// <returns>WebGraphModel</returns>
        WebGraphModel GetStatisticsDetail();

        /// <summary>
        /// Reports the user.
        /// </summary>
        /// <param name="WishListId">The wish list identifier.</param>
        /// <returns></returns>
        bool ReportUser(string WishListId);

        /// <summary>
        /// Searches the unreviewd client.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <returns>List of WebClientWishListModel</returns>
        List<WebClientWishListModel> SearchUnreviewdClient(string searchBy);

        /// <summary>
        /// Searches the client for myclient page.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// List of WebClientWishListModel
        /// </returns>
        List<WebClientWishListModel> SearchClientForMyclientPage(string searchBy, int lastPageId = 0, int numberOfRecords = 10, int sortBy = 0, int direction = 1);

        /// <summary>
        /// Gets the client review.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>WebClientReviewModel</returns>
        WebClientReviewModel GetClientReview(string wishListId, string interest);

        /// <summary>
        /// Saves the image.
        /// </summary>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        MediaStatusMessage SaveImage(byte[] fileBytes, string fileName);

        /// <summary>
        /// Marks as purchased.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>true/false</returns>
        bool MarkAsPurchased(string wishListId, string interest);

        /// <summary>
        /// Gets the dashboard.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        WebCompanyDashboardModel GetDashboard(int lastPageId = 0, int numberOfRecords = 8, string interest = "");

        /// <summary>
        /// Gets the dashboard clients.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        List<WebClientWishListModel> GetDashboardClients(int lastPageId = 0, int numberOfRecords = 8, string interest = "");

        /// <summary>
        /// Sends the multi part message.
        /// </summary>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="messageModel">The message model.</param>
        MediaStatusMessage SendAttachment(byte[] fileBytes, WebMessageModel messageModel);
       
    }
}
