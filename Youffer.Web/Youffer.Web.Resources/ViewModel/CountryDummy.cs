using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Resources.ViewModel
{
    public class CountryDummy
    {
        public string Iso { get; set; }
        public string Isd { get; set; }
        public string Display { get { return string.Format("{0}({1})", Iso, Isd);} }
    }
}
