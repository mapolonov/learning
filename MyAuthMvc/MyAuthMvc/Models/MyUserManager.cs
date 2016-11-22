using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyAuthMvc.Models
{
    public class MyUserManager
    {
        private readonly List<MyUser> _accounts = new List<MyUser>();
        public MyUserManager()
        {
            _accounts.Add(new MyUser() { Username = "acc1", Password = "123", Email = "acc1@mail.com", Roles = new[] { "root" } });
            _accounts.Add(new MyUser() { Username = "acc2", Password = "123", Email = "acc2@mail.com", Roles = new[] { "admin" } });
            _accounts.Add(new MyUser() { Username = "acc3", Password = "123", Email = "acc3@mail.com", Roles = new[] { "user" } });
        }

        public MyUser Find(string username, string password)
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