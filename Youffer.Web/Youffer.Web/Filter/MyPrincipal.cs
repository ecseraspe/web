using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Youffer.Web.Resources.ViewModel;

namespace Youffer.Web.Filter
{
    public class MyPrincipal : IPrincipal
    {
        public MyPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        public WebYoufferUserModel User { get; set; }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
}