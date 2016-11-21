using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyAuthMvc.Models
{
    public class MyAccountManager
    {
        private readonly List<MyAccount> _accounts = new List<MyAccount>();
        public MyAccountManager()
        {
            _accounts.Add(new MyAccount() { Username = "acc1", Password = "123", Roles = new[] { "root" } });
            _accounts.Add(new MyAccount() { Username = "acc2", Password = "123", Roles = new[] { "admin" } });
            _accounts.Add(new MyAccount() { Username = "acc3", Password = "123", Roles = new[] { "user" } });
        }

        public MyAccount Find(string username, string password)
        {
            return _accounts.FirstOrDefault(p => p.Username == username && p.Password == password);
        }

        public string[] GetRoles(string username)
        {
            var acc = _accounts.FirstOrDefault(p => p.Username == username);

            return acc?.Roles;
        }
    }
}