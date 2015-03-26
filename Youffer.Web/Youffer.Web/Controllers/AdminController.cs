using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Youffer.Web.Filter;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Controllers
{
    [YoufferAuthorize()]
    public class AdminController : BaseController
    {
        /// <summary>
        /// Dashboards this instance.
        /// </summary>
        /// <returns>ActionResult
        /// </returns>
        public ActionResult Dashboard()
        {
            WebCompanyDashboardModel model = ClientService.GetDashboard();
            if (model == null)
                return RedirectToAction("Index", "Home");

            if (model.SubBusinessType == null || !model.SubBusinessType.Any())
                model.SubBusinessType = new string[] { };

            WebCompanyDashboardModel sessionModel = new WebCompanyDashboardModel()
            {
                CompanyLogo = model.CompanyLogo,
                CompanyName = model.CompanyName
            };

            @Session["CompanyModel"] = sessionModel;
            return View("NewDashboard", model);
        }

        /// <summary>
        /// Gets the dashboard client.
        /// </summary>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <param name="interest">The interest.</param>
        /// <returns>ActionResult </returns>
        public ActionResult GetDashboardClient(int lastPageId = 0, int numberOfRecords = 8, string interest = "")
        {
            List<WebClientWishListModel> wishList = ClientService.GetDashboardClients(lastPageId, numberOfRecords, interest);
            if (wishList.Any())
            {
                return AuthJson(new { count = wishList.Count(), view = RenderPartialViewToString("_ListClients", wishList) });
            }
            else
            {
                return AuthJson(new { count = 0, view = string.Empty });
            }
        }

        /// <summary>
        /// Searches the client on dashboard -existing clients.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult SearchClientOnDashboard()
        {
            var searchBy = Request.Form["txtClientSearch"];
            WebCompanyDashboardModel res = ClientService.GetDashboard(0, 10, searchBy);
            return PartialView("_Clients", res.ClientWishList);
        }

        /// <summary>
        /// Invoiceses this instance.
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Invoices()
        {
            return View();
        }
    }
}