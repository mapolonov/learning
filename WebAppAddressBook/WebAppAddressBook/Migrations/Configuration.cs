using WebAppAddressBook.Models;

namespace WebAppAddressBook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebAppAddressBook.Models.EFContext";
        }

        protected override void Seed(Models.EFContext context)
        {
            context.Contacts.AddOrUpdate(
              p => p.Name,
              new Contact { Name = "João Sousa", Address = "Street x", City = "Porto", Country = "Portugal" },
              new Contact { Name = "Steve Jon", Address = "Street y", City = "Porto", Country = "Portugal" },
              new Contact { Name = "Peter", Address = "Street z", City = "Porto", Country = "Portugal" }
            );
        }
    }
}
