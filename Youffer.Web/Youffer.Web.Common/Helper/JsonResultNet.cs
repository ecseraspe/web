﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;

namespace Youffer.Web.Common.Helper
{
    public class JsonNetResult : JsonResult
    {
        //public override void ExecuteResult(ControllerContext context)
        //{
        //    if (context == null)
        //        throw new ArgumentNullException("context");
        //    var response = context.HttpContext.Response;
        //    response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
        //    if (ContentEncoding != null)
        //        response.ContentEncoding = ContentEncoding;
        //    if (Data == null)
        //        return;
        //    // If you need special handling, you can call another form of SerializeObject below
        //    var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented,
        //    new JsonSerializerSettings { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat, DateTimeZoneHandling = DateTimeZoneHandling.Utc });
        //    response.Write(serializedObject);
        //}
    }

}
