//-----------------------------------------------------------------------------------------
// <copyright file="CommonService.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>19-Nov-2014</datecreated>
// <summary>
//      Defines the CommonService type
// </summary>
//-----------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Models;
using Youffer.Resources.ViewModel;
using Youffer.Web.Common.Service;
using Youffer.Web.Common.Helper;
using Youffer.Web.Resources.ViewModel;
using AutoMapper;
using Youffer.Web.Common.Dummy;
using Youffer.Web.Common.Extensions;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Net.Configuration;
using System.Configuration;

namespace Youffer.Web.Framework
{
    /// <summary>
    /// Defines type CommonService
    /// </summary>
    public class CommonService : ICommonService
    {
        /// <summary>
        /// Gets all business types.
        /// </summary>
        /// <returns>List of WebBusinessTypesModel</returns>
        public List<WebBusinessTypesModel> GetAllBusinessTypes()
        {
            HttpResultData<List<string>> res = HttpClientHelper.Get<List<string>>(ApiHelper.GetAllBusinessTypes);
            List<WebBusinessTypesModel> businessTypes = new List<WebBusinessTypesModel>();


            if (string.IsNullOrEmpty(res.ErrorMessages))
            {
                foreach (var item in res.Items)
                {
                    businessTypes.Add(new WebBusinessTypesModel() { BusinessType = item, BusinessTypeId = item });
                }

                return businessTypes;
            }

            return new List<WebBusinessTypesModel>();
        }

        /// <summary>
        /// Gets all sub interest.
        /// </summary>
        /// <param name="interest">The interest.</param>
        /// <returns>
        /// List of WebBusinessTypesModel
        /// </returns>
        public List<WebBusinessTypesModel> GetAllSubInterest(string interest)
        {
            string api = string.Format(ApiHelper.GetSubBusinessTypeApi, interest);
            HttpResultData<List<WebBusinessTypesModel>> res = HttpClientHelper.Get<List<WebBusinessTypesModel>>(api);
            if (string.IsNullOrEmpty(res.ErrorMessages))
            {
                return res.Items;
            }

            return res.Items;
        }

        /// <summary>
        /// Gets the home page client.
        /// </summary>
        /// <param name="searchBy">The search by.</param>
        /// <param name="lastPageId">The last page identifier.</param>
        /// <param name="numberOfRecords">The number of records.</param>
        /// <returns></returns>
        public List<WebClientWishListModel> GetHomePageClient(string searchBy = "", int lastPageId = 0, int numberOfRecords = 8)
        {
            searchBy = searchBy.Trim().ToLower();
            var api = string.Format(ApiHelper.GetHomePageTopLead, searchBy, lastPageId, numberOfRecords);
            HttpResultData<List<UserResultModel>> topClients = HttpClientHelper.Get<List<UserResultModel>>(api);
            if (topClients.Items.IsAny())
                topClients.Items = topClients.Items.OrderByDescending(k => k.Rank).ToList();
            if (string.IsNullOrEmpty(topClients.ErrorMessages))
            {
                List<WebClientWishListModel> res = Mapper.Map<List<UserResultModel>, List<WebClientWishListModel>>(topClients.Items);
                if (!string.IsNullOrEmpty(searchBy))
                {
                    foreach (var item in res)
                    {
                        item.SubInterest = item.SubInterest.Where(p => p.ToLower().Contains(searchBy)).ToArray();
                    }
                }

                return res;
            }
            return new List<WebClientWishListModel>();
        }

        /// <summary>
        /// Gets all country.
        /// </summary>
        /// <returns>List of WebCountryModel</returns>
        public List<WebCountryModel> GetAllCountry()
        {
            var res = HttpClientHelper.Get<List<WebCountryModel>>(ApiHelper.GetAllCountryApi);
            List<WebCountryModel> countryList = res.Items;
            return countryList;
        }

        public bool SendMail(MailMessage model)
        {
            return MailRouter.SendSmtpEmail(model);
        }

        /// <summary>
        /// Contacts the us.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public bool ContactUs(ContactUsDto model)
        {
            bool result = false;
            try
            {
                HttpResultData<StatusMessage> returnConfirmation = HttpClientHelper.Post<ContactUsDto, StatusMessage>(ApiHelper.ContactUsApi, model);
                if (string.IsNullOrEmpty(returnConfirmation.ErrorMessages) && returnConfirmation.Items != null)
                {
                    result = returnConfirmation.Items.IsSuccess;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Gets all country calling code.
        /// </summary>
        /// <returns></returns>
        public List<CountryDummy> GetAllCountryCallingCode()
        {
            List<CountryDummy> countryCodes = new List<CountryDummy> { 
            new CountryDummy { Iso = "AF", Isd = "93" },
            new CountryDummy { Iso = "AL", Isd = "355" },
            new CountryDummy { Iso = "DZ", Isd = "213" },
            new CountryDummy { Iso = "AS", Isd = "1684" },
            new CountryDummy { Iso = "AD", Isd = "376" },
            new CountryDummy { Iso = "AO", Isd = "244" },
            new CountryDummy { Iso = "AI", Isd = "1264" },
            new CountryDummy { Iso = "AQ", Isd = "672" },
            new CountryDummy { Iso = "AG", Isd = "1268" },
            new CountryDummy { Iso = "AR", Isd = "54" },
            new CountryDummy { Iso = "AM", Isd = "374" },
            new CountryDummy { Iso = "AW", Isd = "297" },
            new CountryDummy { Iso = "AU", Isd = "61" },
            new CountryDummy { Iso = "AT", Isd = "43" },
            new CountryDummy { Iso = "AZ", Isd = "994" },
            new CountryDummy { Iso = "BS", Isd = "1242" },
            new CountryDummy { Iso = "BH", Isd = "973" },
            new CountryDummy { Iso = "BD", Isd = "880" },
            new CountryDummy { Iso = "BB", Isd = "1246" },
            new CountryDummy { Iso = "BY", Isd = "375" },
            new CountryDummy { Iso = "BE", Isd = "32" },
            new CountryDummy { Iso = "BZ", Isd = "501" },
            new CountryDummy { Iso = "BJ", Isd = "229" },
            new CountryDummy { Iso = "BM", Isd = "1441" },
            new CountryDummy { Iso = "BT", Isd = "975" },
            new CountryDummy { Iso = "BO", Isd = "591" },
            new CountryDummy { Iso = "BA", Isd = "387" },
            new CountryDummy { Iso = "BW", Isd = "267" },
            new CountryDummy { Iso = "BR", Isd = "55" },
            new CountryDummy { Iso = "VG", Isd = "1284" },
            new CountryDummy { Iso = "BN", Isd = "673" },
            new CountryDummy { Iso = "BG", Isd = "359" },
            new CountryDummy { Iso = "BF", Isd = "226" },
            new CountryDummy { Iso = "BI", Isd = "257" },
            new CountryDummy { Iso = "CV", Isd = "238" },
            new CountryDummy { Iso = "KH", Isd = "855" },
            new CountryDummy { Iso = "CM", Isd = "237" },
            new CountryDummy { Iso = "CA", Isd = "1" },
            new CountryDummy { Iso = "KY", Isd = "1345" },
            new CountryDummy { Iso = "CF", Isd = "236" },
            new CountryDummy { Iso = "TD", Isd = "235" },
            new CountryDummy { Iso = "CL", Isd = "56" },
            new CountryDummy { Iso = "CN", Isd = "86" },
            new CountryDummy { Iso = "CO", Isd = "57" },
            new CountryDummy { Iso = "KM", Isd = "269" },
            new CountryDummy { Iso = "CG", Isd = "242" },
            new CountryDummy { Iso = "CD", Isd = "243" },
            new CountryDummy { Iso = "CK", Isd = "682" },
            new CountryDummy { Iso = "CR", Isd = "506" },
            new CountryDummy { Iso = "CI", Isd = "225" },
            new CountryDummy { Iso = "HR", Isd = "385" },
            new CountryDummy { Iso = "CU", Isd = "53" },
            new CountryDummy { Iso = "CW", Isd = "5999" },
            new CountryDummy { Iso = "CY", Isd = "357" },
            new CountryDummy { Iso = "CZ", Isd = "420" },
            new CountryDummy { Iso = "DJ", Isd = "253" },
            new CountryDummy { Iso = "DM", Isd = "1767" },
            new CountryDummy { Iso = "DO", Isd = "18" },
            new CountryDummy { Iso = "EC", Isd = "593" },
            new CountryDummy { Iso = "EG", Isd = "20" },
            new CountryDummy { Iso = "SV", Isd = "503" },
            new CountryDummy { Iso = "GQ", Isd = "240" },
            new CountryDummy { Iso = "ER", Isd = "291" },
            new CountryDummy { Iso = "EE", Isd = "372" },
            new CountryDummy { Iso = "ET", Isd = "251" },
            new CountryDummy { Iso = "FK", Isd = "500" },
            new CountryDummy { Iso = "FO", Isd = "298" },
            new CountryDummy { Iso = "FJ", Isd = "679" },
            new CountryDummy { Iso = "FI", Isd = "358" },
            new CountryDummy { Iso = "FR", Isd = "33" },
            new CountryDummy { Iso = "GF", Isd = "594" },
            new CountryDummy { Iso = "PF", Isd = "689" },
            new CountryDummy { Iso = "GA", Isd = "241" },
            new CountryDummy { Iso = "GM", Isd = "220" },
            new CountryDummy { Iso = "GE", Isd = "995" },
            new CountryDummy { Iso = "DE", Isd = "49" },
            new CountryDummy { Iso = "GH", Isd = "233" },
            new CountryDummy { Iso = "GI", Isd = "350" },
            new CountryDummy { Iso = "GR", Isd = "30" },
            new CountryDummy { Iso = "GL", Isd = "299" },
            new CountryDummy { Iso = "GD", Isd = "1473" },
            new CountryDummy { Iso = "DO", Isd = "18" },
            new CountryDummy { Iso = "GP", Isd = "590" },
            new CountryDummy { Iso = "GU", Isd = "1671" },
            new CountryDummy { Iso = "GT", Isd = "502" },
            new CountryDummy { Iso = "GN", Isd = "224" },
            new CountryDummy { Iso = "GW", Isd = "245" },
            new CountryDummy { Iso = "GY", Isd = "592" },
            new CountryDummy { Iso = "HT", Isd = "509" },
            new CountryDummy { Iso = "VA", Isd = "3" },
            new CountryDummy { Iso = "HN", Isd = "504" },
            new CountryDummy { Iso = "HK", Isd = "852" },
            new CountryDummy { Iso = "HU", Isd="36"},
            new CountryDummy { Iso = "IS", Isd="354"},
            new CountryDummy { Iso = "IN", Isd="91"},
            new CountryDummy { Iso = "ID", Isd="62"},
            new CountryDummy { Iso = "IR", Isd="98"},
            new CountryDummy { Iso = "IQ", Isd="964"},
            new CountryDummy { Iso = "IE", Isd="353"},
            new CountryDummy { Iso = "IL", Isd="972"},
            new CountryDummy { Iso = "IT", Isd="39"},
            new CountryDummy { Iso = "JM", Isd="1876"},
            new CountryDummy { Iso = "JP", Isd="81"},
            new CountryDummy { Iso = "JO", Isd="962"},
            new CountryDummy { Iso = "KZ", Isd="7"},
            new CountryDummy { Iso = "KE", Isd="254"},
            new CountryDummy { Iso = "KI", Isd="686"},
            new CountryDummy { Iso = "KR", Isd="82"},
            new CountryDummy { Iso = "KW", Isd="965"},
            new CountryDummy { Iso = "KG", Isd="996"},
            new CountryDummy { Iso = "LA", Isd="856"},
            new CountryDummy { Iso = "LV", Isd="371"},
            new CountryDummy { Iso = "LB", Isd="961"},
            new CountryDummy { Iso = "LS", Isd="266"},
            new CountryDummy { Iso = "LR", Isd="231"},
            new CountryDummy { Iso = "LY", Isd="218"},
            new CountryDummy { Iso = "LI", Isd="423"},
            new CountryDummy { Iso = "LT", Isd="370"},
            new CountryDummy { Iso = "LU", Isd="352"},
            new CountryDummy { Iso = "MO", Isd="853"},
            new CountryDummy { Iso = "MK", Isd="389"},
            new CountryDummy { Iso = "MG", Isd="261"},
            new CountryDummy { Iso = "MW", Isd="265"},
            new CountryDummy { Iso = "MY", Isd="60"},
            new CountryDummy { Iso = "MV", Isd="960"},
            new CountryDummy { Iso = "ML", Isd="223"},
            new CountryDummy { Iso = "MT", Isd="356"},
            new CountryDummy { Iso = "MH", Isd="692"},
            new CountryDummy { Iso = "MQ", Isd="596"},
            new CountryDummy { Iso = "MR", Isd="222"},
            new CountryDummy { Iso = "MU", Isd="230"},
            new CountryDummy { Iso = "YT", Isd="269"},
            new CountryDummy { Iso = "MX", Isd="52"},
            new CountryDummy { Iso = "FM", Isd="691"},
            new CountryDummy { Iso = "MD", Isd="373"},
            new CountryDummy { Iso = "MC", Isd="377"},
            new CountryDummy { Iso = "MN", Isd="976"},
            new CountryDummy { Iso = "ME", Isd="382"},
            new CountryDummy { Iso = "MS", Isd="1664"},
            new CountryDummy { Iso = "MA", Isd="212"},
            new CountryDummy { Iso = "MZ", Isd="258"},
            new CountryDummy { Iso = "MM", Isd="95"},
            new CountryDummy { Iso = "NA", Isd="264"},
            new CountryDummy { Iso = "NR", Isd="674"},
            new CountryDummy { Iso = "NP", Isd="977"},
            new CountryDummy { Iso = "NL", Isd="31"},
            new CountryDummy { Iso = "NC", Isd="687"},
            new CountryDummy { Iso = "NZ", Isd="64"},
            new CountryDummy { Iso = "NI", Isd="505"},
            new CountryDummy { Iso = "NE", Isd="227"},
            new CountryDummy { Iso = "NG", Isd="234"},
            new CountryDummy { Iso = "NU", Isd="683"},
            new CountryDummy { Iso = "MP", Isd="1670"},
            new CountryDummy { Iso = "KP", Isd="850"},
            new CountryDummy { Iso = "NO", Isd="47"},
            new CountryDummy { Iso = "OM", Isd="968"},
            new CountryDummy { Iso = "PK", Isd="92"},
            new CountryDummy { Iso = "PW", Isd="680"},
            new CountryDummy { Iso = "PS", Isd="970"},
            new CountryDummy { Iso = "PA", Isd="507"},
            new CountryDummy { Iso = "PG", Isd="675"},
            new CountryDummy { Iso = "PY", Isd="595"},
            new CountryDummy { Iso = "PE", Isd="51"},
            new CountryDummy { Iso = "PH", Isd="63"},
            new CountryDummy { Iso = "PL", Isd="48"},
            new CountryDummy { Iso = "PT", Isd="351"},
            new CountryDummy { Iso = "PR", Isd="1787"},
            new CountryDummy { Iso = "QA", Isd="974"},
            new CountryDummy { Iso = "RE", Isd="262"},
            new CountryDummy { Iso = "RO", Isd="40"},
            new CountryDummy { Iso = "RU", Isd="7"},
            new CountryDummy { Iso = "RW", Isd="250"},
            new CountryDummy { Iso = "KN", Isd="1869"},
            new CountryDummy { Iso = "LC", Isd="1758"},
            new CountryDummy { Iso = "PM", Isd="508"},
            new CountryDummy { Iso = "VC", Isd="1784"},
            new CountryDummy { Iso = "WS", Isd="685"},
            new CountryDummy { Iso = "SM", Isd="378"},
            new CountryDummy { Iso = "ST", Isd="239"},
            new CountryDummy { Iso = "SA", Isd="966"},
            new CountryDummy { Iso = "SN", Isd="221"},
            new CountryDummy { Iso = "RS", Isd="381"},
            new CountryDummy { Iso = "SC", Isd="248"},
            new CountryDummy { Iso = "SL", Isd="232"},
            new CountryDummy { Iso = "SG", Isd="65"},
            new CountryDummy { Iso = "SX", Isd="1721"},
            new CountryDummy { Iso = "SK", Isd="421"},
            new CountryDummy { Iso = "SI", Isd="386"},
            new CountryDummy { Iso = "SB", Isd="677"},
            new CountryDummy { Iso = "SO", Isd="252"},
            new CountryDummy { Iso = "ZA", Isd="27"},
            new CountryDummy { Iso = "ES", Isd="34"},
            new CountryDummy { Iso = "LK", Isd="94"},
            new CountryDummy { Iso = "SH", Isd="290"},
            new CountryDummy { Iso = "SD", Isd="249"},
            new CountryDummy { Iso = "SR", Isd="597"},
            new CountryDummy { Iso = "SZ", Isd="268"},
            new CountryDummy { Iso = "SE", Isd="46"},
            new CountryDummy { Iso = "CH", Isd="41"},
            new CountryDummy { Iso = "SY", Isd="963"},
            new CountryDummy { Iso = "TW", Isd="886"},
            new CountryDummy { Iso = "TJ", Isd="992"},
            new CountryDummy { Iso = "TZ", Isd="255"},
            new CountryDummy { Iso = "TH", Isd="66"},
            new CountryDummy { Iso = "TL", Isd="670"},
            new CountryDummy { Iso = "TG", Isd="228"},
            new CountryDummy { Iso = "TK", Isd="690"},
            new CountryDummy { Iso = "TO", Isd="676"},
            new CountryDummy { Iso = "TT", Isd="1868"},
            new CountryDummy { Iso = "TN", Isd="216"},
            new CountryDummy { Iso = "TR", Isd="90"},
            new CountryDummy { Iso = "TM", Isd="993"},
            new CountryDummy { Iso = "TC", Isd="1649"},
            new CountryDummy { Iso = "TV", Isd="688"},
            new CountryDummy { Iso = "UG", Isd="256"},
            new CountryDummy { Iso = "UA", Isd="380"},
            new CountryDummy { Iso = "AE", Isd="971"},
            new CountryDummy { Iso = "GB", Isd="44"},
            new CountryDummy { Iso = "US", Isd="1"},
            new CountryDummy { Iso = "UY", Isd="598"},
            new CountryDummy { Iso = "VI", Isd="1340"},
            new CountryDummy { Iso = "UZ", Isd="998"},
            new CountryDummy { Iso = "VU", Isd="678"},
            new CountryDummy { Iso = "VE", Isd="58"},
            new CountryDummy { Iso = "VN", Isd="84"},
            new CountryDummy { Iso = "WF", Isd="681"},
            new CountryDummy { Iso = "YE", Isd="967"},
            new CountryDummy { Iso = "ZM", Isd="260"},
            new CountryDummy { Iso = "ZW", Isd="263"},
            };

            return countryCodes.OrderBy(x => x.Iso).ToList<CountryDummy>();
        }

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns></returns>
        public List<StateModel> GetStates(string country = "")
        {
            List<StateModel> states = new List<StateModel>();
            try
            {
                HttpResultData<List<StateModel>> allStates = HttpClientHelper.Get<List<StateModel>>(ApiHelper.StatesApi);
                if (String.IsNullOrEmpty(allStates.ErrorMessages))
                {
                    states = allStates.Items;
                    var duplicates = allStates.Items.Find(x=> x.StateName == "New York");
                }
            }
            catch (Exception ex)
            {
                YoufferLogger.Log.Info(string.Format("Exception at Commonservice-->GetStates is {0}", ex.Message));
            }

            return states;
        }
    }


}
