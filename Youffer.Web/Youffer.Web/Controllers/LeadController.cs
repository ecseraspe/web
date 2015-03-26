using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Youffer.Web.Models;
using Youffer.Web.Resources.ViewModel;
using System.Collections.Generic;
using Youffer.Web.Filter;
using Youffer.Web.Common.Helper;
using AutoMapper;
using Youffer.Resources.ViewModel;
using Youffer.Web.Common.Extensions;

namespace Youffer.Web.Controllers
{
    [YoufferAuthorize]
    public class LeadController : BaseController
    {
        /// <summary>
        /// Get data for my client page.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        public ActionResult MyClients(int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            List<WebClientWishListModel> wishList = new List<WebClientWishListModel>();
            wishList = ClientService.GetAllClients(lastPageId, numberOfRecords, sortBy, direction);
            string companyId = YoufferSecurity.UserId;
            wishList.ForEach(x => x.CompanyId = companyId);

            if (Request.IsAjaxRequest())
            {
                return AuthJson(this.AuthRenderPartialViewToString("_DisplayClient", wishList), JsonRequestBehavior.AllowGet);
            }
            return View(wishList);
        }

        /// <summary>
        /// Reviews the client.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public ActionResult ReviewClient(string model)
        {
            WebClientWishListModel jsonModel = JsonDeserialize<WebClientWishListModel>(model);
            jsonModel.Review = ClientService.GetClientReview(jsonModel.WishListId, jsonModel.PurchasedInterest);
            if (jsonModel.Review == null)
                jsonModel.Review = new WebClientReviewModel();
            if (Request.IsAjaxRequest())
            {
                return AuthJson(this.AuthRenderPartialViewToString("_ReviewClient", jsonModel));
            }
            return PartialView("_ReviewClient", jsonModel);
        }

        /// <summary>
        /// Reviews the client.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public JsonResult SubmitReviewForm(WebClientWishListModel model)
        {
            string rating = Request["Review.Rating"];
            decimal value = Convert.ToDecimal(rating);
            model.Rating = new WebRatingModel();
            model.Review.Rating = value;
            model.Review.CreatedOn = DateTime.UtcNow;
            model.Review.ModifiedOn = DateTime.UtcNow;
            model.Review.Rating = value;
            model.Review.IsDeleted = false;
            bool result = ClientService.SubmitReviewForm(model);
            WebClientWishListModel webClientWishListModel = ClientService.GetClientProfileAndReview(model.WishListId, model.PurchasedInterest);

            string className = Guid.NewGuid().ToString();
            string title = "Rate";
            string callback = "";
            bool showRating = true;
            bool disabled = true;
            if (string.IsNullOrWhiteSpace(callback))
                callback = "function (value, link) { }";

            WebRatingViewModel webRatingViewModel = new WebRatingViewModel { Disabled = disabled, Rating = (double)webClientWishListModel.Ranking, RatingClassName = className, CallbackMethod = callback, Title = (title + ": "), ShowRating = showRating };
            string ratingHtml = RenderPartialViewToString("~/Views/Common/_Rating.cshtml", webRatingViewModel);
            return AuthJson(new { result = result, clientId = model.WishListId, ratingHtml = ratingHtml });
        }

        [HttpGet]
        public ActionResult MarkAsPurchased(string model)
        {
            WebClientWishListModel wishList = JsonDeserialize<WebClientWishListModel>(model);
            if (wishList != null)
            {
                WebClientReviewModel review = new WebClientReviewModel();
                review.Rating = 5;
                review.Message = "Product purchased";
                wishList.Review = review;
            }

            return PartialView("MarkAsPurchased", wishList);
        }

        /// <summary>
        /// Marks as purchased.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>Action Result</returns>
        [HttpPost]
        public ActionResult MarkAsPurchased(WebClientWishListModel model)
        {
            if (!string.IsNullOrEmpty(model.WishListId) && !string.IsNullOrEmpty(model.PurchasedInterest))
            {
                var res = ClientService.MarkAsPurchased(model.WishListId, model.PurchasedInterest);
                return AuthJson(new { result = res, wishListId = model.WishListId }, JsonRequestBehavior.AllowGet);
            }

            return AuthJson(new { result = false, wishListId = model.WishListId }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Notes the specified wish list identifier.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        public ActionResult Note(string wishListId, long lastPageId = 0, int numberOfRecords = 100, bool isGetMoreData = false)
        {
            WebClientWishListModel result = ClientService.GetNoteHistory(wishListId, lastPageId, numberOfRecords);
            if (result.NoteList != null && result.NoteList.Any())
                result.NoteList = result.NoteList.OrderByDescending(p => p.CreatedOn).ToList();
            result.Note = new WebNoteModel();
            result.Note.UserId = wishListId;
            result.WishListId = wishListId;
            if (isGetMoreData)
            {
                return AuthJson(result, JsonRequestBehavior.AllowGet);
            }

            return PartialView("_Note", result);
        }

        /// <summary>
        /// Get new note.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>ActionResult</returns>
        public ActionResult NewNote(string wishListId, string companyId)
        {
            WebNoteModel model = new WebNoteModel()
            {
                UserId = wishListId,
                CompanyId = companyId
            };

            return PartialView("_NewNote", model);
        }

        /// <summary>
        ///  Submit new note.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        [HttpPost]
        public ActionResult NewNote(WebNoteModel model)
        {
            string userId = Request.Form["UserId"];
            string noteText = Request.Form["NoteText"];
            model.CreatedOn = DateTime.UtcNow;
            model.ModifiedOn = DateTime.UtcNow;
            model.UserId = userId;
            model.IsDeleted = false;
            model.NoteText = noteText;
            var NoteResult = ClientService.SubmitNote(model);
            return AuthJson(new { result = NoteResult });
        }

        /// <summary>
        /// Get new message window.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// ActionResult
        /// </returns>
        public ActionResult Message(string model)
        {
            WebClientWishListModel jsonModel = JsonDeserialize<WebClientWishListModel>(model);
            if (jsonModel.Message == null)
            {
                WebMessageModel msg = new WebMessageModel();
                jsonModel.Message = msg;
            }

            jsonModel.Message.ToUser = jsonModel.WishListId;
            return PartialView("_Message", jsonModel);
        }

        /// <summary>
        /// Submit new message.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Message(WebClientWishListModel model)
        {
            model.Message.ClientWishListId = model.WishListId;
            var result = ClientService.SubmitMessage(model);
            return result.MessageId > 0 ? AuthJson(true, JsonRequestBehavior.AllowGet) : AuthJson(false, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Sends the attachment.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public ActionResult SendAttachment(WebClientWishListModel model)
        {
            if (!string.IsNullOrEmpty(model.Message.MessageDescription))
            {
                WebMessageModel message = model.Message;
                // quick message with html and bulk message 
                if (message.IsHtml)
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(message.MessageDescription);
                    if (string.IsNullOrEmpty(message.FileName))
                    {
                        message.FileName = Guid.NewGuid().ToString() + ".html";
                    }
                    MediaStatusMessage returnMessage = ClientService.SendAttachment(byteArray, message);
                    return AuthJson(new { result = returnMessage.IsSuccess }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    model.Message.ClientWishListId = model.WishListId;
                    var result = ClientService.SubmitMessage(model);
                    return result.MessageId > 0 ? AuthJson(new { result = true }, JsonRequestBehavior.AllowGet) : AuthJson(new { result = false }, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get message history
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <returns>ActionResult</returns>
        public ActionResult MessageHistory(string wishListId)
        {
            var result = ClientService.GetClientMessageHistory(wishListId);
            if (wishListId.ToLower().Equals(GlobalConstants.SuperAdmin.ToLower()))
            {
                result.WishListId = wishListId;
                WebClientModel client = new WebClientModel();
                client.FirstName = client.ClientId = wishListId;
                client.ImageUrl = client.FirstName.GetSuperAdminImage();
                result.Client = client;
            }

            if (Request.IsAjaxRequest())
            {
                return AuthJson(this.AuthRenderPartialViewToString("_MessageHistory", result));
            }
            return PartialView("_MessageHistory", result);
        }

        /// <summary>
        /// Gets the more message history.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="NumberOfRecords">The number of records.</param>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public ActionResult GetMoreMessageHistory(string wishListId, int lastPageId = 0, int NumberOfRecords = 100)
        {
            WebClientWishListModel messageHistory = ClientService.GetClientMessageHistory(wishListId, lastPageId, NumberOfRecords);
            if (Request.IsAjaxRequest())
            {
                if (messageHistory.MessageList.Count() > 0)
                {
                    return AuthJson(this.AuthRenderPartialViewToString("_MessageHistoryContent", messageHistory));
                }
                else
                {
                    return AuthJson("0");
                }
            }

            return AuthJson(messageHistory, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the client.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="interest">The interest.</param>
        /// <returns></returns>
        public ActionResult DeleteClient(string wishListId, string interest)
        {
            bool result = ClientService.DeleteClient(wishListId, interest);
            return AuthJson(new { result = result });
        }

        /// <summary>
        /// Searches the client.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult SearchClientForMyclientPage(string searchBy, int lastPageId = 0, int numberOfRecords = 100, int sortBy = 0, int direction = 1)
        {
            searchBy = string.IsNullOrEmpty(searchBy) ? Request["searchClient"] : searchBy;
            List<WebClientWishListModel> wishList = new List<WebClientWishListModel>();

            if (string.IsNullOrEmpty(searchBy))
            {
                wishList = ClientService.GetAllClients(0, 10, 1, 1);
            }
            else
            {
                wishList = ClientService.SearchClientForMyclientPage(searchBy, lastPageId, numberOfRecords, sortBy, direction);
            }

            if (wishList.Any())
            {
                //return AuthJson(RenderPartialViewToString("_DisplayClient",wishList)); it is rendering as text.
                return PartialView("_DisplayClient", wishList);
            }
            else
            {
                return AuthJson(null, JsonRequestBehavior.AllowGet);
            }
        }

    }
}