//-----------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the BaseController type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Youffer.Web.Common.Service;
using Youffer.Web.Filter;
using Youffer.Web.Framework;
using Youffer.Web.Resources.ViewModel;
namespace Youffer.Web.Controllers
{
    /// <summary>
    /// Defines type BaseController
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// The common service
        /// </summary>
        private readonly ICommonService commonService;

        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService userService;

        /// <summary>
        /// The client service
        /// </summary>
        private readonly IClientService clientService;

        /// <summary>
        /// The payment service
        /// </summary>
        private readonly IPaymentService paymentService;

        public BaseController()
        {
            this.commonService = new CommonService();
            this.userService = new UserService();
            this.clientService = new ClientService();
            this.paymentService = new PaymentService();
        }

        /// <summary>
        /// Gets or sets the common service.
        /// </summary>
        /// <value>
        /// The common service.
        /// </value>
        public ICommonService CommonService
        {
            get
            {
                return this.commonService;
            }
        }

        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        /// <value>
        /// The user service.
        /// </value>
        public IUserService UserService
        {
            get
            {
                return this.userService;
            }
        }

        /// <summary>
        /// Gets the client service.
        /// </summary>
        /// <value>
        /// The client service.
        /// </value>
        public IClientService ClientService
        {
            get
            {
                return this.clientService;
            }
        }

        /// <summary>
        /// Gets the payment service.
        /// </summary>
        /// <value>
        /// The payment service.
        /// </value>
        public IPaymentService PaymentService
        {
            get
            {
                return this.paymentService;
            }
        }

        protected internal new JsonResult Json(object data)
        {
            return new JsonNetResult { Data = data };
        }

        protected internal new JsonResult AuthJson(object data)
        {
            if (!YoufferSecurity.IsAuthenticated)
            {
                return new JsonNetResult { Data = new { error = "Request is not authenticated!!!", AuthError = 1 } };
            }
            else
            {
                return new JsonNetResult { Data = data };
            }
        }

        protected internal new JsonResult AuthJson(object data, JsonRequestBehavior jsonRequestBehavior)
        {
            if (!YoufferSecurity.IsAuthenticated)
            {
                return new JsonNetResult { Data = new { error = "Request is not authenticated!!!", AuthError = 1 } };
            }
            else
            {
                return Json(data, jsonRequestBehavior);
            }
        }

        /// <summary>
        /// JSON Serialization
        /// </summary>
        public string JsonSerializer<T>(T t)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();
            ser.WriteObject(ms, t);
            var jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// JSON Deserialization
        /// </summary>
        public T JsonDeserialize<T>(string jsonString)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            var obj = (T)ser.ReadObject(ms);
            return obj;
        }

        /// <summary>
        /// Gets the get session.
        /// </summary>
        /// <value>
        /// The get session.
        /// </value>
        protected WebCompanyDashboardModel GetSession
        {
            get
            {
                if (@Session["CompanyModel"] != null)
                {
                    WebCompanyDashboardModel model = @Session["CompanyModel"] as WebCompanyDashboardModel;
                    return model;
                }
                else
                {
                    return new WebCompanyDashboardModel();
                }
            }
        }

        private static List<WebBusinessTypesModel> _businessTypes;
        protected static List<WebBusinessTypesModel> BusinessTypes
        {
            get
            {
                if (_businessTypes == null)
                {
                    _businessTypes = new CommonService().GetAllBusinessTypes();
                }
                return _businessTypes;
            }
        }

        private static List<WebCountryModel> _countries;
        protected static List<WebCountryModel> Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CommonService().GetAllCountry();
                }
                return _countries;
            }
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        protected string AuthRenderPartialViewToString(string viewName, object model)
        {
            if (YoufferSecurity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(viewName))
                    viewName = ControllerContext.RouteData.GetRequiredString("action");

                ViewData.Model = model;

                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);

                    return sw.GetStringBuilder().ToString();
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
