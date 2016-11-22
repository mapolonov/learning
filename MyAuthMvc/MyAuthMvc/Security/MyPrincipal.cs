using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace MyAuthMvc.Security
{
    public class MyPrincipal : IPrincipal
    {
        private readonly MyIdentity _myIdentity;

        public MyPrincipal(MyIdentity identity)
        {
            _myIdentity = identity;
        }
        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(role);
        }

        public IIdentity Identity => _myIdentity;
    }
}