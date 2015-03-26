using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Models;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Common.Service
{
    public interface IPaymentService
    {
        /// <summary>
        /// Submits the review form.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// True or False
        /// </returns>
        string CreateRequest(PaymentModel paymentModel);

        /// <summary>
        /// Submits the review form.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// True or False
        /// </returns>
        string GeneratePaypalUrl(PaypalDetailsWrapper wrapper);
    }
}
