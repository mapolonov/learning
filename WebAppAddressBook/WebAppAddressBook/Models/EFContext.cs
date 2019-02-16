using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAppAddressBook.Auth;

namespace WebAppAddressBook.Models
{
    public class EFContext : IdentityDbContext<AppUser>//DbContext
    {
        public EFContext()
            : base("name=DefaultConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}