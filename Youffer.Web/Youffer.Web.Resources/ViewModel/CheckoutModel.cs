using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Resources.Models;

namespace Youffer.Web.Resources.ViewModel
{
    public class CheckoutModel
    {
        public string ClientId { get; set; }
        public string ClientInterest { get; set; }
        public ProductModel Product { get; set; }
        public decimal ProcessingFee { get; set; }
        public string Currency { get; set; }
        public IDictionary<int, string> PaymentMethods
        {
            get
            {
                IDictionary<int, string> dictionary = new Dictionary<int, string>();
                dictionary.Add(1, "Paypal");
                dictionary.Add(2, "G2S");
                dictionary.Add(3, "2CheckOut");
                return dictionary;
            }
        }
    }
}
