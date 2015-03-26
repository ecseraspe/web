//-----------------------------------------------------------------------------------------
// <copyright file="ClientController.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>21-Nov-2014</datecreated>
// <summary>
//      Defines the ClientController type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youffer.Web.Common;
using Youffer.Web.Common.Service;
using Youffer.Web.Filter;
using Youffer.Web.Resources.ViewModel;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using Youffer.Resources.ViewModel;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Controllers
{
    /// <summary>
    /// Defines type ClientController
    /// </summary>
    [YoufferAuthorize]
    public class ClientController : BaseController
    {
        /// <summary>
        /// Purchases the confirmation detail.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PurchaseConfirmationDetail(string clientId)
        {
            WebClientModel clientModel = ClientService.GetClientProfile(clientId);
            return PartialView("_BuyClient", clientModel);
        }

        /// <summary>
        /// Searches this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Search()
        {
            WebClientSearchPanelModel searchModel = new WebClientSearchPanelModel();
            ViewBag.BusinessTypes = BusinessTypes;
            WebCompanyProfileModel companyProfile = ClientService.GetCompanyProfile();
            if (!string.IsNullOrEmpty(companyProfile.Country))
            {
                ViewBag.Country = companyProfile.Country;
            }
            return View(searchModel);
        }

        /// <summary>
        /// Searches the specified search model.
        /// </summary>
        /// <param name="searchModel">The search model.</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Search(WebClientSearchPanelModel searchModel)
        {
            searchModel.AgeFrom = searchModel.AgeFrom == null ? 0 : searchModel.AgeFrom;
            searchModel.AgeTo = searchModel.AgeTo == null ? 0 : searchModel.AgeTo;
            List<WebClientWishListModel> wishList = ClientService.SearchClient(searchModel);
            if (wishList == null || !wishList.Any())
            {
                return AuthJson(new { count = 0, view = "" }, JsonRequestBehavior.AllowGet);
            }
            return AuthJson(new { count = wishList.Count(), view = RenderPartialViewToString("_ListClients", wishList) });
        }

        [HttpPost]
        public ActionResult MoreSearch(string model)
        {
            WebClientSearchPanelModel searchModel = JsonDeserialize<WebClientSearchPanelModel>(model);
            List<WebClientWishListModel> wishList = ClientService.SearchClient(searchModel);
            if (wishList == null || !wishList.Any())
            {
                return AuthJson(new { count = 0, view = "" }, JsonRequestBehavior.AllowGet);
            }

            return AuthJson(new { count = wishList.Count(), view = RenderPartialViewToString("_ListClients", wishList) });
        }

        /// <summary>
        /// Gets the client profile and review.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>ActionResult</returns>
        public ActionResult GetClientProfileAndReview(string wishListId, string interest, bool isPurchased)
        {
            WebClientWishListModel clientProfileAndReviewList = ClientService.GetClientProfileAndReview(wishListId, interest);
            if (isPurchased)
            {
                clientProfileAndReviewList.PurchasedInterest = interest;
            }
            if (Request.IsAjaxRequest())
            {
                return AuthJson(this.AuthRenderPartialViewToString("_ClientProfileAndReview", clientProfileAndReviewList));
            }
            return PartialView("_ClientProfileAndReview", clientProfileAndReviewList);
        }

        /// <summary>
        /// Buys the client.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>ActionResult</returns>
        public ActionResult BuyClient(string wishListId, string interest)
        {
            var res = ClientService.BuyClient(wishListId, interest);
            return AuthJson(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Reviews the client.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        public ActionResult ReviewClient(int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            var wishList = ClientService.ClientsNotReviewed(lastPageId, numberOfRecords, sortBy, direction);
            if (Request.IsAjaxRequest())
            {
                return AuthJson(this.AuthRenderPartialViewToString("_DisplayReviewClient", wishList));
            }

            return View(wishList);
        }

        /// <summary>
        /// Dashboards the not review client.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public ActionResult DashboardNotReviewClient(int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1, bool isScroll = false)
        {
            var wishList = ClientService.ClientsNotReviewed(lastPageId, numberOfRecords, sortBy, direction);
            if (Request.IsAjaxRequest())
            {
                if (isScroll)
                {
                    return AuthJson(this.AuthRenderPartialViewToString("_NewReviewClientContent", wishList));
                }
                else
                {
                    return AuthJson(this.AuthRenderPartialViewToString("_NewReviewClient", wishList));
                }

            }

            return View(wishList);
        }

        /// <summary>
        /// Settingses the specified company identifier.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public ActionResult Settings()
        {
            WebCompanyProfileModel model = new WebCompanyProfileModel();
            model = ClientService.GetCompanyProfile();
            model.CountryCodeList = CommonService.GetAllCountryCallingCode();
            model.BusinessTypes = CommonService.GetAllBusinessTypes();
            ViewBag.message = TempData["MyMessage"] ?? "";
            TempData["MyMessage"] = "";
            return View(model);
        }

        /// <summary>
        /// Settingses the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult Settings(WebCompanyProfileModel model)
        {
            bool result = ClientService.SubmitCompanyProfile(model);

            if (result)
            {
                TempData["MyMessage"] = "Changes saved successfully.";
            }
            else
            {
                TempData["MyMessage"] = "Some error occured. Please try again.";
            }

            return RedirectToAction("Settings");
        }

        /// <summary>
        /// Saves the company image.
        /// </summary>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult SaveCompanyImage()
        {
            if (Request.Files["UploadedImage"] != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedImage"]; // this "UploadedImage" name exists in javascript function.
                if (IsValidExtension(file.FileName))
                {
                    byte[] fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, file.ContentLength);
                    MediaStatusMessage imageResult = ClientService.SaveImage(fileBytes, file.FileName);
                    if (Session["companyModel"] != null)
                    {
                        var sessionModel = Session["companyModel"] as Youffer.Web.Resources.ViewModel.WebCompanyDashboardModel;
                        sessionModel.CompanyLogo = imageResult.MediaUrl;
                        Session["companyModel"] = sessionModel;
                    }
                    return AuthJson(imageResult, JsonRequestBehavior.AllowGet);
                }

                return AuthJson(new MediaStatusMessage { IsSuccess = false, ErrorMessage = "Invalid file. Please upload .jpeg, .jpg, .gif and .png image." }, JsonRequestBehavior.AllowGet);
            }

            return AuthJson(new MediaStatusMessage { IsSuccess = false, ErrorMessage = "Please select file." }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <returns>bool</returns>
        [HttpPost]
        public JsonResult DeleteMessage(long messageId)
        {
            if (messageId > 0)
            {
                return AuthJson(ClientService.DeleteMessage(messageId), JsonRequestBehavior.AllowGet);
            }

            return AuthJson("false", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets all messages.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by. Note: sortBy="" mean default sort on createdon, otherwise pass columnName</param>
        /// <param name="direction">The sort direction. asc and desc</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        public ActionResult AllMessages(int lastPageId = 0, int numberOfRecords = 100, string sortBy = "", string direction = "desc")
        {
            List<WebMessageModel> allMessages = ClientService.GetAllMessage(lastPageId, numberOfRecords, sortBy, direction);

            if (Request.IsAjaxRequest())
            {
                if (allMessages.Any())
                {
                    return AuthJson(RenderPartialViewToString("_AllMessageContent", allMessages));
                }
                else
                {
                    return AuthJson("0", JsonRequestBehavior.AllowGet);
                }
            }

            return View(allMessages);
        }

        public ActionResult DashboardAllMessage(int lastPageId = 0, int numberOfRecords = 100, string sortBy = "", bool isScroll = false, string direction = "desc")
        {
            List<WebMessageModel> allMessages = ClientService.GetAllMessage(lastPageId, numberOfRecords, sortBy, direction);

            if (allMessages.Any())
            {
                if (isScroll)
                {
                    return AuthJson(RenderPartialViewToString("~/Views/Lead/_NewDashboardMessageContent.cshtml", allMessages));
                }
                else
                {
                    return AuthJson(RenderPartialViewToString("~/Views/Lead/_NewDashboardMessage.cshtml", allMessages));
                }
            }
            else
            {
                return AuthJson("0", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Send Instants message.
        /// </summary>
        /// <returns>
        /// WebMessageModel
        /// </returns>
        [HttpPost]
        public JsonResult InstantMessage()
        {
            WebMessageModel returnMsg = new WebMessageModel();
            try
            {
                WebMessageModel msg = new WebMessageModel();
                msg.ClientWishListId = this.Request.Form["hWishListId"];
                msg.MessageDescription = this.Request.Form["txtInstantMessage"];
                if (!string.IsNullOrEmpty(msg.MessageDescription))
                {
                    msg.MessageDescription.Trim();
                }
                msg.DoesContainMedia = false;
                msg.IsHtml = false;
                WebClientWishListModel wishList = new WebClientWishListModel();
                wishList.WishListId = msg.ClientWishListId;
                wishList.Message = msg;
                if (msg.ClientWishListId.Equals(GlobalConstants.SuperAdmin))
                {
                    returnMsg = submitContactUsInsteadOfInstantMessage(msg);
                }
                else
                {
                    returnMsg = ClientService.SubmitMessage(wishList);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            if (returnMsg != null)
            {
                WebClientWishListModel wishList = new WebClientWishListModel();
                wishList.CompanyId = Youffer.Web.Filter.YoufferSecurity.UserId;
                wishList.MessageList = new List<WebMessageModel>() { returnMsg };
                return AuthJson(RenderPartialViewToString("~/Views/Lead/_MessageHistoryContent.cshtml", wishList), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return AuthJson("0", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Submits the contact us instead of instent message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public WebMessageModel submitContactUsInsteadOfInstantMessage(WebMessageModel message)
        {

            ContactUsDto inputModel = new ContactUsDto();
            inputModel.Description = message.MessageDescription;

            if (CommonService.ContactUs(inputModel))
            {
                message.CreatedOn = DateTime.UtcNow;
                message.FromUser = YoufferSecurity.UserId;
                return message;
            }
            else
                return null;
        }

        /// <summary>
        /// Reports the user.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ReportUser(string wishListId)
        {
            var res = ClientService.ReportUser(wishListId);
            return AuthJson(res, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Statisticses this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Statistics()
        {
            WebCompanyProfileModel model = new WebCompanyProfileModel();
            model = ClientService.GetCompanyProfile();
            return View(model);
        }

        /// <summary>
        /// Gets the statictics.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult GetStatictics()
        {
            WebGraphModel model = new WebGraphModel();
            model = ClientService.GetStatisticsDetail();
            List<WebStatisticsModel> statistics = new List<WebStatisticsModel>();
            statistics = model.Statistic;
            var dateJson = "";
            var clientJson = "";
            var ClientsToMakePurchaseJson = "";
            //graphReport =
            //    graphReport.Select(p => new GraphReportModel(){Date = string.Join(",", p.Date), Clicks = string.Join(",", p.Clicks)});
            foreach (var item in statistics)
            {
                DateTime datetime = DateTime.Parse(item.Date);
                string date = datetime.ToShortDateString();
                dateJson += string.Concat(date + ",");
                clientJson += item.NumberofClients + ",";
                ClientsToMakePurchaseJson += item.NumberofPurchases + ",";
            }
            return AuthJson(new { dates = dateJson, TotalClients = clientJson, ClientsToMakePurchase = ClientsToMakePurchaseJson, avgRating = model.AverageRating });
        }

        /// <summary>
        /// Determines whether [is valid extension] [the specified file name].
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>bool</returns>
        private bool IsValidExtension(string fileName)
        {
            var extensions = ConfigurationManager.AppSettings["FileType"].Split(',').ToList();
            return extensions.Any(item => fileName.ToLower().Trim().EndsWith(item.ToLower().Trim()));
        }

        /// <summary>
        /// Files the extension.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>string</returns>
        private static string FileExtension(string fileName)
        {
            return fileName.Substring((fileName.LastIndexOf('.'))).ToLower();
        }

        /// <summary>
        /// Searches the unreview client.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult SearchUnReviewClient()
        {
            string searchBy = Request["txtSearchUnReviewClient"];
            List<WebClientWishListModel> wishList = ClientService.SearchUnreviewdClient(searchBy == null ? string.Empty : searchBy);
            if (wishList.Count() > 0)
            {
                return PartialView("_DisplayReviewClient", wishList);
            }
            else
            {
                return AuthJson(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult CompleteRegister()
        {
            WebCompanyProfileModel companyProfile = ClientService.GetCompanyProfile();
            companyProfile.BusinessTypes = CommonService.GetAllBusinessTypes();
            return PartialView("_CompleteRegistration", companyProfile);
        }

        /// <summary>
        /// Completes the register.
        /// </summary>
        /// <param name="companyModel">The company model.</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult CompleteRegister(WebCompanyProfileModel companyModel)
        {
            companyModel.PhoneNumber = companyModel.PhoneNumber;
            companyModel.CompanyName = companyModel.CompanyName;
            companyModel.SelectedBusinessTypeId = companyModel.SelectedBusinessTypeId;
            bool result = ClientService.CompleteRegistration(companyModel);
            return AuthJson(result, JsonRequestBehavior.AllowGet);
        }
    }
    #region Gaurav Sharma's code

    #endregion
}