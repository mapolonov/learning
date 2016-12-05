using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.EF;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Identity;
using LObject3Tier.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LObject3Tier.DAL.Repositories
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IClientManager _clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ApplicationDbContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
        }

        public ApplicationUserManager UserManager => _userManager;

        public IClientManager ClientManager => _clientManager;

        public ApplicationRoleManager RoleManager => _roleManager;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userManager.Dispose();
                    _roleManager.Dispose();
                    _clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
