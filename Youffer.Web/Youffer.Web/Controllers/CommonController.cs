//-----------------------------------------------------------------------------------------
// <copyright file="CommonController.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>24-Nov-2014</datecreated>
// <summary>
//      Defines the CommonController type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youffer.Web.Common.Service;
using Youffer.Web.Filter;
using Youffer.Web.Resources.ViewModel;
using Youffer.Resources.ViewModel;
using Youffer.Resources.Models;

namespace Youffer.Web.Controllers
{
    /// <summary>
    /// Defines type CommonController
    /// </summary>
    public class CommonController : BaseController
    {
        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult GetAge()
        {
            List<int> age = new List<int>();
            for (int i = 11; i < 70; i++)
            {
                age.Add(i);
            }
            if (Request.IsAjaxRequest())
            {
                return Json(age, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        /// <summary>
        /// Gets all business types.
        /// </summary>
        /// <returns>
        /// ActionResult
        /// </returns>
        [HttpPost]
        public ActionResult GetAllBusinessTypes()
        {
            List<WebBusinessTypesModel> businessTypes = CommonService.GetAllBusinessTypes();
            if (Request.IsAjaxRequest())
            {
                return Json(businessTypes, JsonRequestBehavior.AllowGet);
            }
            return View();
        }


        /// <summary>
        /// Gets all sub interest.
        /// </summary>
        /// <param name="interest">The interest.</param>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult GetAllSubInterest(string interest)
        {
            var subInterests = CommonService.GetAllSubInterest(interest);
            return Json(subInterests, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns>JsonResult</returns>
        [HttpPost]
        public JsonResult GetAllCountry()
        {
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetRating(double rating = 0, bool disabled = false, string className = "wow", string title = "Rate", string callback = "", bool showRating = true, bool isSearchable = false)
        {
            if (string.IsNullOrWhiteSpace(callback))
                callback = "function (value, link) { }";

            WebRatingViewModel model = new WebRatingViewModel { Disabled = disabled, Rating = rating, RatingClassName = Guid.NewGuid().ToString(), CallbackMethod = callback, Title = string.IsNullOrEmpty(title) ? "" : (title + ": "), ShowRating = showRating };
            if (!isSearchable)
                return PartialView("_Rating", model);
            return PartialView("_RatingSpan", model);
        }

        public ActionResult ChatWindowPushNotification(string message)
        {
            MessagesDto messageDto = JsonDeserialize<MessagesDto>(message);
            WebMessageModel messageModel = AutoMapper.Mapper.Map<MessagesDto, WebMessageModel>(messageDto);
            if (messageModel != null)
            {
                WebClientWishListModel wishList = new WebClientWishListModel();
                wishList.CompanyId = messageDto.CompanyId;
                wishList.MessageList = new List<WebMessageModel>() { messageModel };
                return AuthJson(RenderPartialViewToString("~/Views/Lead/_MessageHistoryContent.cshtml", wishList), JsonRequestBehavior.AllowGet);
            }

            return Json("0", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllMessagePushNotification(string message)
        {
            MessagesDto messageDto = JsonDeserialize<MessagesDto>(message);
            WebMessageModel messageModel = AutoMapper.Mapper.Map<MessagesDto, WebMessageModel>(messageDto);
            if (messageModel != null)
            {
                List<WebMessageModel> messageList = new List<WebMessageModel>();
                messageList.Add(messageModel);
                //return PartialView("~/Views/Client/_AllMessageContent.cshtml", messageList);
                return AuthJson(RenderPartialViewToString("~/Views/Client/_AllMessageContent.cshtml", messageList), JsonRequestBehavior.AllowGet);
            }

            return Json("0", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Dashboards all message push notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult DashboardAllMessagePushNotification(string message)
        {
            MessagesDto messageDto = JsonDeserialize<MessagesDto>(message);
            WebMessageModel messageModel = AutoMapper.Mapper.Map<MessagesDto, WebMessageModel>(messageDto);
            if (messageModel != null)
            {
                List<WebMessageModel> messageList = new List<WebMessageModel>();
                messageList.Add(messageModel);
                return AuthJson(RenderPartialViewToString("~/Views/Lead/_NewDashboardMessageContent.cshtml", messageList), JsonRequestBehavior.AllowGet);
            }

            return AuthJson("0", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Landing page.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Download()
        {
            return View();
        }

        /// <summary>
        /// Messages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ViewResult Message(string message)
        {
            ViewBag.ReturnMessage = message;
            return View();
        }

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public JsonResult GetStates(string country)
        {
            List<StateModel> states = CommonService.GetStates(country);
            return Json(new { states = states, JsonRequestBehavior.AllowGet });
        }

    }
}