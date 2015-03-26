//-----------------------------------------------------------------------------------------
// <copyright file="ClientService.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>21-Nov-2014</datecreated>
// <summary>
//      Defines the ClientService type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Web.Common.Helper;
using Youffer.Web.Common.Service;
using Youffer.Web.Resources.ViewModel;
using System.Web;
using System.Web.Script.Serialization;
using AutoMapper;
using Youffer.Web.Framework;
using Youffer.Resources.CRMModel;
using Youffer.Resources.Models;
using Youffer.Resources.ViewModel;
using Youffer.Web.Common.Extensions;
using Newtonsoft.Json;
using System.Web.Mvc;
using Youffer.Web.Common.Dummy;

namespace Youffer.Web.Framework
{
    /// <summary>
    /// Defines type ClientService
    /// </summary>
    public class ClientService : IClientService
    {
        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>List of WebClientWishListModel</returns>
        public List<WebClientWishListModel> GetAllClients(int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            string url = string.Format(ApiHelper.GetAllPurchasedClientsApi, lastPageId, numberOfRecords);
            var result = HttpClientHelper.Get<List<PurchasedClientsDto>>(url);
            List<WebClientWishListModel> list = new List<WebClientWishListModel>();

            if (result.ErrorMessages == null)
            {
                list = Mapper.Map<List<PurchasedClientsDto>, List<WebClientWishListModel>>(result.Items);
            }

            return list;
        }

        /// <summary>
        /// Gets the client profile.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        /// WebClientModel
        /// </returns>
        public WebClientModel GetClientProfile(string clientId)
        {
            string url = string.Format(ApiHelper.GetClientProfileAndReviewApi, clientId);
            var res = HttpClientHelper.Get<UserResultModel>(url);
            WebClientModel model = Mapper.Map<UserResultModel, WebClientModel>(res.Items);
            return model;
        }

        /// <summary>
        /// Submits the review form.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// True or False
        /// </returns>
        public bool SubmitReviewForm(WebClientWishListModel model)
        {
            UserReviewsDto data = Mapper.Map<WebClientWishListModel, UserReviewsDto>(model);
            var res = HttpClientHelper.Post<UserReviewsDto, UserReviewsDto>(ApiHelper.SubmitClientReviewApi, data);
            if (string.IsNullOrEmpty(res.ErrorMessages))
            {
                if (!string.IsNullOrEmpty(res.Items.Id))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Marks as purchased.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>true/false</returns>
        public bool MarkAsPurchased(string wishListId, string interest)
        {
            MarkAsPurchasedDto model = new MarkAsPurchasedDto() { UserId = wishListId, Interest = interest };
            var result = HttpClientHelper.Post<MarkAsPurchasedDto, StatusMessage>(ApiHelper.MarkAsPurchased, model);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                return result.Items.IsSuccess;
            }

            return false;
        }

        /// <summary>
        /// Gets the note history.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <returns>
        /// WebClientWishListModel
        /// </returns>
        public WebClientWishListModel GetNoteHistory(string wishListId, long lastPageId = 0, int numberOfRecords = 100)
        {
            string url = string.Format(ApiHelper.GetClientNotesApi, wishListId);
            var result = HttpClientHelper.Get<List<CompanyNotesDto>>(url);
            List<WebNoteModel> listOfNotes = Mapper.Map<List<CompanyNotesDto>, List<WebNoteModel>>(result.Items);
            WebClientWishListModel wish = new WebClientWishListModel();
            wish.NoteList = listOfNotes;
            return wish;
        }

        /// <summary>
        /// Submits the note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// WebNoteModel Model
        /// </returns>
        public WebNoteModel SubmitNote(WebNoteModel model)
        {
            CompanyNotesDto data = Mapper.Map<WebNoteModel, CompanyNotesDto>(model);
            var result = HttpClientHelper.Post<CompanyNotesDto, CompanyNotesDto>(ApiHelper.SubmitClientNoteApi, data);
            if (string.IsNullOrEmpty(result.ErrorMessages) && result.Items != null)
            {
                if (!string.IsNullOrEmpty(result.Items.Id))
                {
                    return Mapper.Map<CompanyNotesDto, WebNoteModel>(result.Items);
                }
            }

            return new WebNoteModel();
        }

        /// <summary>
        /// Submits the message.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// WebMessageModel
        /// </returns>
        public WebMessageModel SubmitMessage(WebClientWishListModel model)
        {
            model.Message.CreatedOn = DateTime.UtcNow;
            MessagesDto message = Mapper.Map<WebMessageModel, MessagesDto>(model.Message);
            HttpResultData<MessagesDto> result = HttpClientHelper.Post<MessagesDto, MessagesDto>(ApiHelper.SaveMessageApi, message);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                if (result.Items.Id > 0)
                {
                    return Mapper.Map<MessagesDto, WebMessageModel>(result.Items);
                }
            }

            return new WebMessageModel();
        }

        /// <summary>
        /// Sends the attachment.
        /// </summary>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="messageModel">The message model.</param>
        /// <returns></returns>
        public MediaStatusMessage SendAttachment(byte[] fileBytes, WebMessageModel messageModel)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (messageModel.IsBulkMessage)
            {
                dict.Add(Youffer.Web.Common.Dummy.DummyData.IsBulkMessage, "1");
            }
            else
            {
                dict.Add(Youffer.Web.Common.Dummy.DummyData.ToUserId, messageModel.ToUser);
            }

            HttpResultData<MediaStatusMessage> returnMessage = HttpClientHelper.PostMultiPart<MediaStatusMessage>(ApiHelper.SendAttachment, fileBytes, messageModel.FileName, dict);
            if (string.IsNullOrEmpty(returnMessage.ErrorMessages))
            {
                return returnMessage.Items;
            }

            return new MediaStatusMessage();

        }

        /// <summary>
        /// Deletes the client.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        public bool DeleteClient(string wishListId, string interest)
        {
            string url = string.Format(ApiHelper.DeleteClientApi, wishListId, interest);
            var result = HttpClientHelper.Delete<bool>(url);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                return result.Items;
            }

            return false;
        }

        /// <summary>
        /// Searches the client.
        /// </summary>
        /// <param name="searchModel">The search model.</param>
        /// <returns>List of WebClientWishListModel</returns>
        public List<WebClientWishListModel> SearchClient(WebClientSearchPanelModel searchModel)
        {
            searchModel.SubInterestName = searchModel.SubInterestName.ToLower();
            var res = HttpClientHelper.Post<WebClientSearchPanelModel, List<UserResultModel>>(ApiHelper.SearchClientApi, searchModel);
            if (!string.IsNullOrEmpty(res.ErrorMessages) && res.Items != null)
            {
                return new List<WebClientWishListModel>();
            }
            if (!string.IsNullOrEmpty(searchModel.SubInterestName))
            {
                res.Items.Each(x => x.SubInterest = new[] { x.SubInterest.Where(p => p.ToLower().Contains(searchModel.SubInterestName)).FirstOrDefault() });
            }

            List<WebClientWishListModel> wishList = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(res.Items).OrderByDescending(s => s.Ranking).ToList();

            return wishList;
        }

        /// <summary>
        /// Gets the client profile and review.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>
        /// WebClientWishListModel
        /// </returns>
        public WebClientWishListModel GetClientProfileAndReview(string wishListId, string interest = "")
        {
            string url = string.Format(ApiHelper.GetClientProfileAndReviewApi, wishListId);
            var result = HttpClientHelper.Get<UserResultModel>(url);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                result.Items.SubInterest = string.IsNullOrEmpty(interest) ? result.Items.SubInterest : new string[] { interest };
                return Mapper.Map<UserResultModel, WebClientWishListModel>(result.Items); ;
            }

            return new WebClientWishListModel();
        }

        /// <summary>
        /// Buys the client.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>int</returns>
        public bool BuyClient(string wishListId, string interest)
        {
            string url = string.Format(ApiHelper.BuyUserApi, wishListId, interest);
            HttpResultData<bool> buyResult = HttpClientHelper.Post<bool>(url);
            if (string.IsNullOrEmpty(buyResult.ErrorMessages))
            {
                return buyResult.Items;
            }

            return false;
        }

        /// <summary>
        /// Not reviewed clients.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// List of WebClientWishListModel
        /// </returns>
        public List<WebClientWishListModel> ClientsNotReviewed(int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            List<WebClientWishListModel> wishList = new List<WebClientWishListModel>();
            var url = string.Format(ApiHelper.GetUnReviewdClientApi, lastPageId, numberOfRecords);
            var result = HttpClientHelper.Get<List<UserResultModel>>(url);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                wishList = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(result.Items);
                wishList.Each(x => x.PurchasedInterest = x.SubInterest.FirstOrDefault());
                return wishList;
            }
            return wishList;
        }

        /// <summary>
        /// Gets the company profile.
        /// </summary>
        /// <returns>
        /// WebCompanyProfileModel
        /// </returns>
        public WebCompanyProfileModel GetCompanyProfile()
        {
            WebCompanyProfileModel companyProfile = new WebCompanyProfileModel();
            try
            {
                HttpResultData<OrgResultModel> companyProfileResult = HttpClientHelper.Get<OrgResultModel>(ApiHelper.GetCompanyDetailApi);
                if (string.IsNullOrEmpty(companyProfileResult.ErrorMessages))
                {
                    companyProfile = Mapper.Map<OrgResultModel, WebCompanyProfileModel>(companyProfileResult.Items);
                    string arr = string.Join(",", companyProfile.SelectedSubBusinessTypes);
                    companyProfile.SelectedBusinessTypeId = arr;
                    WebCompanyPaymentModel payment = new WebCompanyPaymentModel();
                    payment.SelectedPaymentMode = "Paypal";
                    payment.IsPaypal = true;
                    payment.IsCard = false;
                    payment.PaypalAccount = "12345656";
                    companyProfile.Payment = payment;
                    return companyProfile;
                }
            }
            catch (Exception ex)
            {
                YoufferLogger.Log.Info(string.Format("ClientService-->GetCompanyProfile exception : {0}", ex.Message));
            }

            return companyProfile;
        }

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
        public List<WebMessageModel> GetAllMessage(int lastPageId = 0, int numberOfRecords = 100, string sortBy = "", string direction = "desc")
        {
            string url = string.Format(ApiHelper.GetAllCompanyMessages, lastPageId, numberOfRecords, sortBy, direction);
            var result = HttpClientHelper.Get<List<MessagesDto>>(url);

            List<WebMessageModel> allMessage = new List<WebMessageModel>();
            if (result.ErrorMessages == null)
            {
                allMessage = Mapper.Map<List<MessagesDto>, List<WebMessageModel>>(result.Items);
            }

            return allMessage;
        }

        /// <summary>
        /// Clients the message history.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="NumberOfRecords">The number of records.</param>
        /// <returns>
        /// True or False
        /// </returns>
        public WebClientWishListModel GetClientMessageHistory(string wishListId, int lastPageId = 0, int NumberOfRecords = 100)
        {
            string url = string.Format(ApiHelper.GetClientMessagesApi, wishListId, lastPageId, NumberOfRecords, "", GlobalConstants.SortDirectionAscending);
            var messageHistory = HttpClientHelper.Get<List<MessagesDto>>(url);
            WebClientModel client = GetClientProfile(wishListId);
            WebClientWishListModel wish = new WebClientWishListModel();
            List<WebMessageModel> allMessage = new List<WebMessageModel>();
            if (string.IsNullOrEmpty(messageHistory.ErrorMessages) && messageHistory.Items.Count > 0)
            {
                wish.CompanyId = messageHistory.Items.First().CompanyId;
                allMessage = Mapper.Map<List<MessagesDto>, List<WebMessageModel>>(messageHistory.Items);
                foreach (WebMessageModel message in allMessage)
                {
                    if (message.MessageMedia != null)
                    {
                        message.MessageMedia.FileName = message.MessageMedia.FileName.ToMediaUrl();
                    }
                }
            }

            wish.WishListId = wishListId;
            wish.MessageList = allMessage;
            wish.Client = client;
            return wish;
        }
        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="messageId">The message identifier.</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool DeleteMessage(long messageId)
        {
            string url = string.Format(ApiHelper.DeleteMessageApi, messageId);
            HttpResultData<bool> result = HttpClientHelper.Delete<bool>(url);
            if (string.IsNullOrEmpty(result.ErrorMessages))
            {
                return result.Items;
            }

            return false;
        }

        /// <summary>
        /// Submits the company profile.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// bool
        /// </returns>
        public bool SubmitCompanyProfile(WebCompanyProfileModel model)
        {
            WebCompanyProfileModel profileDetail = GetCompanyProfile();
            profileDetail.CompanyName = model.CompanyName;
            profileDetail.CompanyId = model.CompanyId;
            profileDetail.FacebookUrl = model.FacebookUrl;
            profileDetail.ImageUrl = model.ImageUrl;
            profileDetail.PhoneNumber = model.PhoneNumber;
            profileDetail.SelectedSubBusinessTypes = profileDetail.SelectedMainBusinessTypes = model.SelectedBusinessTypeId.Split(',');
            profileDetail.WebsiteUrl = model.WebsiteUrl;
            profileDetail.CountryCode = model.CountryCode;

            OrganisationModel organisationDetails = Mapper.Map<WebCompanyProfileModel, OrganisationModel>(profileDetail);
            HttpResultData<OrgResultModel> companyDetails = HttpClientHelper.Post<OrganisationModel, OrgResultModel>(ApiHelper.UpdateCompanyDetailApi, organisationDetails);
            if (String.IsNullOrEmpty(companyDetails.ErrorMessages))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Completes the registration.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>bool</returns>
        public bool CompleteRegistration(WebCompanyProfileModel model)
        {
            WebCompanyProfileModel profileDetail = GetCompanyProfile();
            profileDetail.CompanyName = model.CompanyName;
            profileDetail.SelectedMainBusinessTypes = model.SelectedBusinessTypeId.Split(',');
            profileDetail.PhoneNumber = model.PhoneNumber;
            OrganisationModel organisationDetails = Mapper.Map<WebCompanyProfileModel, OrganisationModel>(profileDetail);
            HttpResultData<OrgResultModel> companyDetails = HttpClientHelper.Post<OrganisationModel, OrgResultModel>(ApiHelper.UpdateCompanyDetailApi, organisationDetails);
            if (string.IsNullOrEmpty(companyDetails.ErrorMessages))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Reports the user.
        /// </summary>
        /// <param name="WishListId">The wish list identifier.</param>
        /// <returns>true or false</returns>
        public bool ReportUser(string WishListId)
        {
            FeedbackDto feedback = new FeedbackDto() { ToId = WishListId };
            HttpResultData<FeedbackDto> feedbackResult = HttpClientHelper.Post<FeedbackDto, FeedbackDto>(ApiHelper.ReportUserApi, feedback);
            if (string.IsNullOrEmpty(feedbackResult.ErrorMessages) && feedbackResult.Items.Id > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the unreviewd client.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <returns>List of WebClientWishListModel</returns>
        public List<WebClientWishListModel> SearchUnreviewdClient(string searchBy)
        {
            var url = string.Format(ApiHelper.SearchUnreviewdClientApi, searchBy);
            HttpResultData<List<UserResultModel>> unReviewedClient = HttpClientHelper.Get<List<UserResultModel>>(url);
            if (string.IsNullOrEmpty(unReviewedClient.ErrorMessages))
            {
                var wishList = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(unReviewedClient.Items);
                wishList.Each(x => x.PurchasedInterest = x.SubInterest.FirstOrDefault());
                return wishList;
            }

            return new List<WebClientWishListModel>();
        }

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
        public List<WebClientWishListModel> SearchClientForMyclientPage(string searchBy, int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            var api = string.Format(ApiHelper.SearchMyClientsApi, searchBy, lastPageId, numberOfRecords);
            HttpResultData<List<UserResultModel>> myClients = HttpClientHelper.Get<List<UserResultModel>>(api);
            if (string.IsNullOrEmpty(myClients.ErrorMessages))
            {
                List<WebClientWishListModel> searchResult = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(myClients.Items);
                searchResult.Each(x => x.PurchasedInterest = x.SubInterest.FirstOrDefault());
                return searchResult;
            }
            else
            {
                return new List<WebClientWishListModel>();
            }

        }

        /// <summary>
        /// Gets the client review.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>
        /// WebClientReviewModel
        /// </returns>
        public WebClientReviewModel GetClientReview(string wishListId, string interest)
        {
            string url = string.Format(ApiHelper.GetClientReviewApi, wishListId);
            var result = HttpClientHelper.Get<List<UserReviewsDto>>(url);
            if (string.IsNullOrEmpty(result.ErrorMessages) && result.Items != null)
            {
                List<WebClientReviewModel> clientReview = Mapper.Map<List<UserReviewsDto>, List<WebClientReviewModel>>(result.Items);
                WebClientReviewModel review = clientReview.Where(p => p.InterestName.Equals(interest, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                return review;
            }

            return new WebClientReviewModel(); //clientReview;
        }

        /// <summary>
        /// Gets the statistics detail.
        /// </summary>
        /// <returns></returns>
        public WebGraphModel GetStatisticsDetail()
        {
            var graphResult = HttpClientHelper.Get<List<StatisticsModelDto>>(ApiHelper.GetStatisticsDetailApi);
            WebGraphModel graph = new WebGraphModel();
            graph.Statistic = new List<WebStatisticsModel>();
            if (string.IsNullOrEmpty(graphResult.ErrorMessages) && graphResult.Items.Any())
            {
                StatisticsModelDto fullGraphDetail = graphResult.Items[0];
                graph.AverageRating = Math.Round(fullGraphDetail.AvgRating, 2);
                for (int i = 0; i < 30; i++)
                {
                    DateTime date = DateTime.UtcNow.AddDays(-i).Date;
                    int clientOnDate = 0, clientPurchasedOndate = 0;

                    DictModel clients = fullGraphDetail.Clients.FirstOrDefault(x => Convert.ToDateTime(x.Key).Date.Equals(date));
                    clientOnDate = clients == null ? 0 : Convert.ToInt32(clients.Value);

                    DictModel purchasedClient = fullGraphDetail.PurchasedClients.FirstOrDefault(x => Convert.ToDateTime(x.Key).Date.Equals(date));
                    clientPurchasedOndate = purchasedClient == null ? 0 : Convert.ToInt32(purchasedClient.Value);

                    graph.Statistic.Add(new WebStatisticsModel()
                    {
                        Date = date.ToShortDateString(),
                        NumberofClients = clientOnDate,
                        NumberofPurchases = clientPurchasedOndate
                    });
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    DateTime date = DateTime.UtcNow.AddDays(-i);
                    graph.Statistic.Add(new WebStatisticsModel()
                    {
                        Date = date.ToShortDateString(),
                        NumberofClients = 0,
                        NumberofPurchases = 0
                    });
                }
            }

            return graph;
        }

        public MediaStatusMessage SaveImage(byte[] fileBytes, string fileName)
        {
            var res = HttpClientHelper.UploadImage<MediaStatusMessage>(ApiHelper.SaveCompanyImageApi, fileBytes, fileName);
            //// no need to validate the result because error message is include in res.items
            return res.Items;

        }

        /// <summary>
        /// Gets the dashboard.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>
        /// WebCompanyDashboardModel
        /// </returns>
        public WebCompanyDashboardModel GetDashboard(int lastPageId = 0, int numberOfRecords = 100, string interest = "")
        {
            List<WebClientWishListModel> listOfWishList = GetDashboardClients(lastPageId, numberOfRecords);
            // We will delete this row after API paging implementation
            if (!AppSettings.Get<bool>("IsApiPagingInabled", true))
            {
                if (listOfWishList.Count > 8) listOfWishList = listOfWishList.Take(8).ToList();
            }

            /********Company details*********/
            string country = "";
            var CompanyDetail = HttpClientHelper.Get<OrgResultModel>(ApiHelper.GetCompanyDetailApi);
            if (CompanyDetail != null && CompanyDetail.Items != null)
            {
                try
                {
                    country = CompanyDetail.Items.CountryDetails.CountryName.Equals("india", StringComparison.InvariantCultureIgnoreCase) ? CompanyDetail.Items.CountryDetails.CountryName : "Others";
                    var res = string.Format(ApiHelper.GetPaymentConfigDetailApi + "?country={0}", country);
                    var paymentConigInfo = HttpClientHelper.Get<List<PaymentConfigInfoDto>>(res);
                    System.Web.HttpContext.Current.Session["PaymentConfig"] = paymentConigInfo.Items[0];
                }
                catch
                {

                }
            }
            WebCompanyDashboardModel dashboard = Mapper.Map<OrgResultModel, WebCompanyDashboardModel>(CompanyDetail.Items);

            dashboard.CompanyLogo = string.IsNullOrWhiteSpace(dashboard.CompanyLogo) ? DummyData.NoImage : dashboard.CompanyLogo;
            if (!string.IsNullOrEmpty(interest))
            {
                foreach (var item in listOfWishList)
                {
                    item.SubInterest = new string[1] { interest };
                }
            }

            dashboard.ClientWishList = listOfWishList;
            return dashboard;
        }

        /// <summary>
        /// Gets the dashboard clients.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        public List<WebClientWishListModel> GetDashboardClients(int lastPageId = 0, int numberOfRecords = 100, string interest = "")
        {
            List<WebClientWishListModel> listOfWishList = new List<WebClientWishListModel>();
            var res = string.Format(ApiHelper.GetDashbaordApi, lastPageId, numberOfRecords) + "&interest=" + interest.Trim();
            var dashBoard = HttpClientHelper.Get<List<UserResultModel>>(res);
            if (dashBoard.ErrorMessages != null)
                return listOfWishList;
            listOfWishList = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(dashBoard.Items);
            listOfWishList = listOfWishList.OrderByDescending(k => k.Ranking).ToList();
            return listOfWishList;
        }

    }
}


