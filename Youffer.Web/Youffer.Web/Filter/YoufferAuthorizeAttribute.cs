//-----------------------------------------------------------------------------------------
// <copyright file="YoufferAuthorizeAttribute.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>1-Dec-2014</datecreated>
// <summary>
//      Defines the YoufferAuthorizeAttribute type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Youffer.Web.Filter
{
    /// <summary>
    ///  Defines type YoufferAuthorizeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class YoufferAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if (!YoufferSecurity.IsAuthenticated)
                {
                    YoufferSecurity.LogOut();
                    RouteToDefault(filterContext);
                }
            }
        }

        /// <summary>
        /// Routes to default.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        private void RouteToDefault(ActionExecutingContext filterContext)
        {
            RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
            redirectTargetDictionary.Add("action", "Index");
            redirectTargetDictionary.Add("controller", "Home");
            filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
        }
    }


}