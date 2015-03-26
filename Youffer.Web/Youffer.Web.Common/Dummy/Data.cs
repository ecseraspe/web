using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Youffer.Web.Resources.ViewModel;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Common.Dummy
{
    public static class DummyData
    {
        public static string CompanyLogo { get { return "img/companyLogo.jpg"; } }
        public static string NoImage { get { return "/img/noImg.png"; } }
        /// <summary>
        /// User Id to send attachment
        /// </summary>
        public static string ToUserId = "ToUserId";
        /// <summary>
        /// 1 for true else false
        /// </summary>
        public static string IsBulkMessage = "IsBulkMessage";

        /// <summary>
        /// Homes the page client.
        /// </summary>
        /// <returns></returns>
        public static List<WebClientWishListModel> HomePageClient()
        {
            List<WebClientWishListModel> clients = new List<WebClientWishListModel>();

            WebClientWishListModel client1 = new WebClientWishListModel();

            client1.SubInterest = new string[] { "Adventure Tourism" };
            WebClientModel clientModel1 = new WebClientModel();
            clientModel1.Age = 27;
            clientModel1.FirstName = "Sophia";
            clientModel1.ImageUrl = "img/client-pic2.png";
            clientModel1.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client1.Client = clientModel1;
            client1.Ranking = 5;
            clients.Add(client1);

            WebClientWishListModel client2 = new WebClientWishListModel();
            WebClientModel clientModel2 = new WebClientModel();
            client2.SubInterest = new string[] { "Account Collector" };
            clientModel2.Age = 45;
            clientModel2.FirstName = "Emma";
            clientModel2.ImageUrl = "img/client-pic9.png";
            clientModel2.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client2.Client = clientModel2;
            client2.Ranking = 5;

            clients.Add(client2);

            WebClientWishListModel client3 = new WebClientWishListModel();
            WebClientModel clientModel3 = new WebClientModel();
            client3.SubInterest = new string[] { "Accountant" };
            clientModel3.Age = 24;
            clientModel3.FirstName = "Gaetano";
            clientModel3.ImageUrl = "img/client-pic4.png";
            clientModel3.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client3.Client = clientModel3;
            client3.Ranking = 5;

            clients.Add(client3);

            WebClientWishListModel client4 = new WebClientWishListModel();
            WebClientModel clientModel4 = new WebClientModel();
            client4.SubInterest = new string[] { "3-D Photos" };
            clientModel4.Age = 35;
            clientModel4.FirstName = "Hamilton";
            clientModel4.ImageUrl = "img/client-pic3.png";
            clientModel4.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client4.Client = clientModel4;
            client4.Ranking = 5;

            clients.Add(client4);

            WebClientWishListModel client5 = new WebClientWishListModel();
            WebClientModel clientModel5 = new WebClientModel();
            client5.SubInterest = new string[] { "Accountant" };
            clientModel5.Age = 22;
            clientModel5.FirstName = "Olivia";
            clientModel5.ImageUrl = "img/client-pic5.jpg";
            clientModel5.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client5.Client = clientModel5;
            client5.Ranking = 5;

            clients.Add(client5);

            WebClientWishListModel client6 = new WebClientWishListModel();
            WebClientModel clientModel6 = new WebClientModel();
            client6.SubInterest = new string[] { "Electrician" };
            clientModel6.Age = 50;
            clientModel6.FirstName = "Eddie";
            clientModel6.ImageUrl = "img/client-pic6.jpg";
            clientModel6.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client6.Client = clientModel6;
            client6.Ranking = 4;

            clients.Add(client6);

            WebClientWishListModel client7 = new WebClientWishListModel();
            WebClientModel clientModel7 = new WebClientModel();
            client7.SubInterest = new string[] { "Graphic Artist" };
            clientModel7.Age = 50;
            clientModel7.FirstName = "Calvin";
            clientModel7.ImageUrl = "img/client-pic7.jpg";
            clientModel7.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client7.Client = clientModel7;
            client7.Ranking = 4;

            clients.Add(client7);

            WebClientWishListModel client8 = new WebClientWishListModel();
            WebClientModel clientModel8 = new WebClientModel();
            client8.SubInterest = new string[] { "3-D Photos" };
            clientModel8.Age = 45;
            clientModel8.FirstName = "Wallace";
            clientModel8.ImageUrl = "img/client-pic8.jpg";
            clientModel8.Flag = AppSettings.ApiBaseUrl + "Flags/US.gif";
            client8.Client = clientModel8;
            client8.Ranking = 4;

            clients.Add(client8);

            return clients;
        }

    }
}
