using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Web.Common.Helper;
using Youffer.Web.Common.Service;
using Youffer.Web.Resources.ViewModel;
using System.Web;
using AutoMapper;
using Youffer.Web.Framework;
using Youffer.Resources.CRMModel;
using Youffer.Resources.Models;
using Youffer.Resources.ViewModel;

namespace Youffer.Web.Framework
{
    /// <summary>
    /// Defines type ClientService
    /// </summary>
    public class PaymentService : IPaymentService
    {
        public string CreateRequest(PaymentModel paymentModel)
        {
            var res = HttpClientHelper.Post<PaymentModel, string>(ApiHelper.CreateG2SRequestApi, paymentModel);
            if (string.IsNullOrEmpty(res.ErrorMessages))
            {
                return res.Items;
            }

            return null;
        }

        public string GeneratePaypalUrl(PaypalDetailsWrapper wrapper)
        {
            string result = string.Empty;
            var res = HttpClientHelper.Post<PaypalDetailsWrapper, string>(ApiHelper.PaypalUrl, wrapper);
            if (string.IsNullOrEmpty(res.ErrorMessages))
            {
                return res.Items;
            }
            return result;
        }
    }
}
