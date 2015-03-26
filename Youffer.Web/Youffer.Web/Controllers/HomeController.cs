using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Youffer.Web.Filter;
using Youffer.Web.Framework;
using Youffer.Web.Resources.ViewModel;
using System.Net.Configuration;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Youffer.Web.Common.Dummy;
using Youffer.Web.Common.Helper;
using Youffer.Web.Common.Extensions;
using System.Text.RegularExpressions;

namespace Youffer.Web.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            if (DeviceDetector.GetDeviceType(Request.UserAgent).ToLower() == "android_mobile")
            {
                return View("MobileIndex");
            }

            if (YoufferSecurity.IsAuthenticated)
                return RedirectToAction("Dashboard", "Admin");


            return View();
        }

        /// <summary>
        /// Tops rated clients.
        /// </summary>
        /// <returns></returns>
        public ActionResult TopRated()
        {
            List<WebClientWishListModel> model = new List<WebClientWishListModel>();
            if (AppSettings.Get<bool>(GlobalConstants.IsDummyKey, false) == true)
            {
                model = DummyData.HomePageClient();
            }
            else
            {
                model = CommonService.GetHomePageClient(string.Empty, 0, 8) ?? new List<WebClientWishListModel>();
            }

            if (model.Any())
            {
                return PartialView("_ListClients", model);
            }

            return Json("0", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Searches the home page clients.
        /// </summary>
        /// <param name="searchText">The search text.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <returns>ActionResult</returns>
        public ActionResult SearchHomePageClients(string searchText = "", int lastPageId = 0, int numberOfRecords = 8)
        {
            var interest = string.IsNullOrEmpty(searchText) ? Request.Form["HomPageClientInterest"] : searchText;
            List<WebClientWishListModel> model = new List<WebClientWishListModel>();
            if (AppSettings.Get<bool>(GlobalConstants.IsDummyKey, false) == true && string.IsNullOrEmpty(interest))
            {
                if (lastPageId < 2)
                {
                    model = DummyData.HomePageClient();
                }
            }
            else
            {
                model = CommonService.GetHomePageClient(interest == null ? string.Empty : interest, lastPageId, numberOfRecords);
            }

            if (model.IsAny())
            {
                return PartialView("_ListClients", model);
            }

            return Json("0", JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Contact()
        {
            WebContactModel model = new WebContactModel { ReturnMessage = "" };
            return View(model);
        }

        [HttpPost]
        public JsonResult Contact(WebContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid) return AuthJson(new { result = false });
                string emailTemplate = "<!DOCTYPE html><html lang='en'>	<body>		<h4>The following enquiry has been submitted.</h4>		<table style='width: 500px; background-color: rgb(243, 243, 243);'><tbody>			<tr style='text-align:left; padding:8px;'>				<th>Name</th>				<td></td>				<td>##firstname##</td>			<tr style='text-align:left; padding:8px;'>				<th>Email Id</th>				<td></td>				<td>##email##</td>			</tr>			<tr style='text-align:left; padding:8px;'>				<th>Message</th>				<td></td>				<td>##message##</td>			</tr>		</tbody>		</table>	</body></html>";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailerAddress"], "Youffer");
                mail.To.Add(ConfigurationManager.AppSettings["OwnerAddress"]);
                mail.Subject = ConfigurationManager.AppSettings["Mailersubject"];
                emailTemplate = emailTemplate.Replace("##firstname##", contact.Name)
                .Replace("##email##", contact.EmailId)
                .Replace("##message##", contact.Message);
                mail.IsBodyHtml = true;
                mail.Body = emailTemplate;
                if (CommonService.SendMail(mail))
                {
                    return Json(new { result = true });
                }
                else
                {
                    return Json(new { result = false });
                }
            }
            catch
            {
                return Json(new { result = false });
            }
        }

        /// <summary>
        /// Termsands the condition.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult TermsandCondition()
        {
            return View();
        }

        /// <summary>
        /// Whats the is youffer.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult WhatIsYouffer()
        {
            return View();
        }

        /// <summary>
        /// Hows it works.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult HowItWorks()
        {
            return View();
        }

        /// <summary>
        /// Privacies the policy.
        /// </summary>
        /// <returns></returns>
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}