using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Youffer.Resources.Models;
using Youffer.Web.Common.Helper;
using Youffer.Web.Filter;
using Youffer.Web.Resources.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Youffer.Web.Controllers
{
    public class PaymentController : BaseController
    {
        [HttpPost]
        [YoufferAuthorize]
        public ActionResult Checkout(string clientId, string clientInterest)
        {
            WebClientModel webClientModel = ClientService.GetClientProfile(clientId);
            CheckoutModel checkoutModel = new CheckoutModel();
            ProductModel productModel = new ProductModel()
            {
                Id = webClientModel.ClientId,
                Title = webClientModel.FirstName + " - " + clientInterest,
                Price = YoufferSecurity.CurrentAmount //AppSettings.Get<decimal>("interestPrice")
            };
            checkoutModel.Product = productModel;
            //checkoutModel.ProcessingFee = (checkoutModel.Product.Price * AppSettings.Get<decimal>("processingFeePercent")) / 100;
            checkoutModel.ProcessingFee = (checkoutModel.Product.Price * YoufferSecurity.ProcessingFeePercentage) / 100;
            checkoutModel.ClientId = clientId;
            checkoutModel.ClientInterest = clientInterest;
            return View(checkoutModel);
        }



        [HttpPost]
        [YoufferAuthorize]
        public ActionResult ProceedToPayment(string PaymentMethod, string productTitle, PaymentModel paymentModel)
        {
            bool iframe = AppSettings.Get<bool>("g2SiFrameEnabled");
            int currentAmount = YoufferSecurity.CurrentAmount;
            decimal processingFeePercent = YoufferSecurity.ProcessingFeePercentage;
            Uri currentUrl = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string currentDomain = currentUrl.GetLeftPart(UriPartial.Authority);
            if (!string.IsNullOrWhiteSpace(PaymentMethod) && PaymentMethod.Trim().Equals("1", StringComparison.InvariantCultureIgnoreCase))
            {
                decimal pricing = Convert.ToDecimal(currentAmount + (currentAmount * processingFeePercent) / 100);
                PaypalDetailsWrapper wrapper = new PaypalDetailsWrapper
                {
                    PaypalDetails = new PaypalDetails {
                        Domain = currentDomain,
                        Currency = "USD"
                    }
                };
                
                List<PayPalDetailsModel> paypalDetailList = new List<PayPalDetailsModel>();
                
                paypalDetailList.Add(new PayPalDetailsModel
                {
                    Id = paymentModel.ClientId,
                    Name = productTitle,
                    Need = paymentModel.ClientInterest,
                    Price = pricing
                });
                wrapper.ItemDetails = paypalDetailList;
                string paypalUrl = PaymentService.GeneratePaypalUrl(wrapper);

                if (!string.IsNullOrWhiteSpace(paypalUrl))
                    return Redirect(paypalUrl);
            }
            else if (PaymentMethod.Trim() == "2")
            {
                if (iframe)
                {
                    string url = PaymentService.CreateRequest(paymentModel);
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return View("G2SPay", (object)url);
                }
                else
                {
                    string url = PaymentService.CreateRequest(paymentModel);
                    return Redirect(url);
                }
            }
            else if (PaymentMethod.Trim() == "3")
            {
                var checkOutModel = new CheckOutDetailsModel
               {
                   Id = paymentModel.ClientId,
                   Name = productTitle,
                   Need = paymentModel.ClientInterest,
                   Price = YoufferSecurity.CurrentAmount,
                   ProcessingFee = YoufferSecurity.ProcessingAmount,
                   URL2CO = AppSettings.Get<string>("2COUrl"),
                   Mode2CO = AppSettings.Get<string>("2COMode"),
                   AccountNo = AppSettings.Get<string>("2COAccountNumber"),
                   CurrencyCode = AppSettings.Get<string>("2COCurrencyCode"),
                   UserId = Youffer.Web.Filter.YoufferSecurity.UserId
               };
                return PayWith2CO(checkOutModel);
            }

            WebClientModel webClientModel = ClientService.GetClientProfile(paymentModel.ClientId);
            CheckoutModel checkoutModel = new CheckoutModel();
            ProductModel productModel = new ProductModel()
            {
                Id = webClientModel.ClientId,
                Title = webClientModel.FirstName + " - " + paymentModel.ClientInterest,
                Price = YoufferSecurity.CurrentAmount
            };
            checkoutModel.Product = productModel;
            checkoutModel.ProcessingFee = (checkoutModel.Product.Price * YoufferSecurity.ProcessingFeePercentage) / 100;
            checkoutModel.ClientId = paymentModel.ClientId;
            checkoutModel.ClientInterest = paymentModel.ClientInterest;
            ViewBag.Message = "Please select a valid option.";
            return View("Checkout", checkoutModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PayWith2CO(CheckOutDetailsModel model)
        {
            List<CheckOutDetailsModel> checkoutDetailList = new List<CheckOutDetailsModel> { model };
            return View("Payment2CO", checkoutDetailList);
        }

        [HttpGet]
        public ActionResult Done(string status)
        {
            if (status.ToLower() == "success")
            {
                return View("Success");
            }
            else if (status.ToLower() == "error")
            {
                return View("Failure");
            }
            else if (status.ToLower() == "cancelled")
            {
                return View("Cancelled");
            }
            else
            {
                return View("Pending");
            }
        }
    }
}