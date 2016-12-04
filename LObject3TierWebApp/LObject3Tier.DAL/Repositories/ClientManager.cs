using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.EF;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Interfaces;

namespace LObject3Tier.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationDbContext Database { get; set; }

        public ClientManager(ApplicationDbContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
