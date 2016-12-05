﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LObject3Tier.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

        static ApplicationDbContext()
        {
            //Использовать если хотим запретить CodeFirst 
            //и проверку измененной модели и хеш кода в таблице __MigrationHistory
            Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}
