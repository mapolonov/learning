using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using MyAuthMvc.Models;

namespace MyAuthMvc.Security
{
    public class MyIdentity : IIdentity
    {
        public IIdentity Identity { get; set; }
        public MyUser MyUser { get; set; }
        public MyIdentity(MyUser user)
        {
            MyUser = user;
            Identity = new GenericIdentity(user.Username);
        }
        public string Name => Identity.Name;
        public string AuthenticationType => Identity.AuthenticationType;
        public bool IsAuthenticated => Identity.IsAuthenticated;
    }
}