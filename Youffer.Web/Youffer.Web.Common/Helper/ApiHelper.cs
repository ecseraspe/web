using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// ApiHelper
    /// </summary>
    public static class ApiHelper
    {
        /// <summary>
        /// Gets the get client profile and review API.
        /// </summary>
        /// <value>
        /// The get client profile and review API.
        /// </value>
        public static string GetClientProfileAndReviewApi { get { return "api/company/userprofile/{0}"; } }

        /// <summary>
        /// Gets the get all clients API.
        /// </summary>
        /// <value>
        /// The get all clients API.
        /// </value>
        public static string GetAllPurchasedClientsApi { get { return "api/company/purchasedclients?lastPageId={0}&fetchCount={1}"; } }

        /// <summary>
        /// Gets the buy user API.
        /// </summary>
        /// <value>
        /// The buy user API.
        /// </value>
        public static string BuyUserApi { get { return "api/company/buyuser?userId={0}&interest={1}"; } }

        /// <summary>
        /// Gets the search client.
        /// </summary>
        /// <value>
        /// The search client.
        /// </value>
        public static string SearchClientApi { get { return "api/company/searchclient"; } }

        /// <summary>
        /// Gets the get payment config detail.
        /// </summary>
        /// <value>
        /// The get payment config detail.
        /// </value>
        public static string GetPaymentConfigDetailApi { get { return "api/company/payment-config"; } }

        /// <summary>
        /// Gets the get company detail.
        /// </summary>
        /// <value>
        /// The get company detail.
        /// </value>
        public static string GetCompanyDetailApi { get { return "api/company/company-details"; } }

        /// <summary>
        /// Gets the update company detail.
        /// </summary>
        /// <value>
        /// The update company detail.
        /// </value>
        public static string UpdateCompanyDetailApi { get { return "api/company/updatecompany"; } }

        /// <summary>
        /// Gets the type of the get main business.
        /// </summary>
        /// <value>
        /// The type of the get main business.
        /// </value>
        public static string GetMainBusinessTypeApi { get { return "api/common/get-mainbusinesstypes"; } }

        /// <summary>
        /// Gets the type of the get sub business.
        /// </summary>
        /// <value>
        /// The type of the get sub business.
        /// </value>
        public static string GetSubBusinessTypeApi { get { return "api/common/get-subbusinesstypes?interest={0}"; } }

        /// <summary>
        /// Gets the get dashbaord.
        /// </summary>
        /// <value>
        /// The get dashbaord.
        /// </value>
        public static string GetDashbaordApi { get { return "api/company/getdashboard?lastPageId={0}&fetchCnt={1}"; } }

        /// <summary>
        /// Gets the get all country.
        /// </summary>
        /// <value>
        /// The get all country.
        /// </value>
        public static string GetAllCountryApi { get { return "api/common/countries"; } }

        /// <summary>
        /// Gets the get un reviewd client API.
        /// </summary>
        /// <value>
        /// The get un reviewd client API.
        /// </value>
        public static string GetUnReviewdClientApi { get { return "api/company/unreviewedclients?lastpageId={0}&fetchCount={1}"; } }

        /// <summary>
        /// Gets the statistic Detail.
        /// </summary>
        /// <value>
        /// The get statistic Detail.
        /// </value>
        public static string GetStatisticsDetailApi { get { return "api/company/get-statistics"; } }

        /// <summary>
        /// Gets the get client review API.
        /// </summary>
        /// <value>
        /// The get client review API.
        /// </value>
        //public static string GetClientReviewApi { get { return "api/company/{0}/user-reviews"; } }
        public static string GetClientReviewApi { get { return "api/company/user-reviews/{0}"; } }


        /// <summary>
        /// Gets the submit client review API.
        /// </summary>
        /// <value>
        /// The submit client review API.
        /// </value>
        public static string SubmitClientReviewApi { get { return "api/company/saveuser-review"; } }

        /// <summary>
        /// Gets the mark as purchased.
        /// </summary>
        /// <value>
        /// The mark as purchased.
        /// </value>
        public static string MarkAsPurchased { get { return "/api/company/mark-purchased"; } }

        /// <summary>
        /// Gets the get client notes API.
        /// </summary>
        /// <value>
        /// The get client notes API.
        /// </value>
        public static string GetClientNotesApi { get { return "api/company/company-notes/{0}"; } }

        /// <summary>
        /// Gets the submit client note API.
        /// </summary>
        /// <value>
        /// The submit client note API.
        /// </value>
        public static string SubmitClientNoteApi { get { return "api/company/savecompany-note"; } }

        /// <summary>
        /// Gets the delete client API.
        /// </summary>
        /// <value>
        /// The delete client API.
        /// </value>
        public static string DeleteClientApi { get { return "api/company/deleteclient?userId={0}&interest={1}"; } }


        /// <summary>
        /// Gets the get all company messages.
        /// Note: sortBy="" for default sort on created on
        /// </summary>
        /// <value>
        /// The get all company messages.
        /// </value>
        public static string GetAllCompanyMessages { get { return "api/company/getcompanymessages?lastpageId={0}&fetchCount={1}&sortBy={2}&direction={3}"; } }

        /// <summary>
        /// Gets the get client messages API.
        /// </summary>
        /// <value>
        /// The get client messages API.
        /// </value>
        public static string GetClientMessagesApi { get { return "api/company/{0}/getmessages?lastpageId={1}&fetchCount={2}&sortBy={3}&direction={4}"; } }

        /// <summary>
        /// Gets the save message API.
        /// </summary>
        /// <value>
        /// The save message API.
        /// </value>
        public static string SaveMessageApi { get { return "api/company/createmessage"; } }

        /// <summary>
        /// Gets the get home page top lead.
        /// </summary>
        /// <value>
        /// The get home page top lead.
        /// </value>
        public static string GetHomePageTopLead { get { return "api/common/top-leads?interest={0}&lastpageId={1}&fetchCount={2}"; } }

        /// <summary>
        /// Gets the search my clients.
        /// </summary>
        /// <value>
        /// The search my clients.
        /// </value>
        public static string SearchMyClientsApi { get { return "api/company/searchclientmyclientpage?searchText={0}&lastpageId={1}&fetchCount={2}"; } }

        /// <summary>
        /// Gets the get all interest.
        /// </summary>
        /// <value>
        /// The get all interest.
        /// </value>
        //public static string GetAllBusinessTypes { get { return "api/common/get-interests"; } } Note: changed from API
        public static string GetAllBusinessTypes { get { return "api/common/get-businesstypes"; } }

        /// <summary>
        /// Gets the register user from form API.
        /// </summary>
        /// <value>
        /// The register user from form API.
        /// </value>
        public static string RegisterUserFromFormApi { get { return "api/account/register"; } }

        /// <summary>
        /// Gets the search unreviewd client API.
        /// </summary>
        /// <value>
        /// The search unreviewd client API.
        /// </value>
        //public static string SearchUnreviewdClientApi { get { return "api/company/{0}/searchclientreviewpage"; } }
        public static string SearchUnreviewdClientApi { get { return "api/company/searchclientreviewpage?searchText={0}"; } }

        /// <summary>
        /// Gets the save company image.
        /// </summary>
        /// <value>
        /// The save company image.
        /// </value>
        public static string SaveCompanyImageApi { get { return "api/common/profileimage"; } }

        /// <summary>
        /// Gets the report user API.
        /// </summary>
        /// <value>
        /// The report user API.
        /// </value>
        public static string ReportUserApi { get { return "api/company/reportuser"; } }

        /// <summary>
        /// Gets the form login API.
        /// </summary>
        /// <value>
        /// The form login API.
        /// </value>
        public static string FormLoginApi { get { return "token"; } }

        /// <summary>
        /// Gets the external login API. Note 0 for "Provider", 1 for ExternalAccessToken
        /// </summary>
        /// <value>
        /// The external login API.
        /// </value>
        public static string ExternalLoginApi { get { return "api/account/ObtainLocalAccessToken?provider={0}&externalAccessToken={1}"; } }

        /// <summary>
        /// Gets the g2s payment url API.
        /// </summary>
        /// <value>
        /// The submit g2s API.
        /// </value>
        public static string CreateG2SRequestApi { get { return "api/payment/createrequest"; } }

        /// <summary>
        /// Gets the delete message API.
        /// </summary>
        /// <value>
        /// The delete message API.
        /// </value>
        public static string DeleteMessageApi { get { return "/api/company/deletethread?threadId={0}"; } }

        /// <summary>
        /// Gets the send attachment.
        /// </summary>
        /// <value>
        /// The send attachment.
        /// </value>
        public static string SendAttachment { get { return "/api/common/attachment"; } }

        /// <summary>
        /// Gets the paypal payment url API.
        /// </summary>
        /// <value>
        /// The submit g2s API.
        /// </value>
        public static string PaypalUrl { get { return "api/payment/paypalurl"; } }

        /// <summary>
        /// Gets the forgot password request API.
        /// </summary>
        /// <value>
        /// The forgot password request API.
        /// </value>
        public static string ForgotPasswordRequestApi { get { return "/api/account/SendResetPasswordLink?email={0}"; } }

        /// <summary>
        /// Gets the update forgot password API.
        /// </summary>
        /// <value>
        /// The update forgot password API.
        /// </value>
        public static string UpdateForgotPasswordApi { get { return "/api/account/updatePassword"; } }

        /// <summary>
        /// Gets the change password API.
        /// </summary>
        /// <value>
        /// The change password API.
        /// </value>
        public static string ChangePasswordApi { get { return "/api/account/updatePassword"; } }

        /// <summary>
        /// Gets the contact us API.
        /// </summary>
        /// <value>
        /// The contact us API.
        /// </value>
        public static string ContactUsApi { get { return "/api/company/contactusmessage"; } }

        /// <summary>
        /// Gets the state API.
        /// </summary>
        /// <value>
        /// The state API.
        /// </value>
        public static string StatesApi { get { return "/api/common/states"; } }
    }
}
