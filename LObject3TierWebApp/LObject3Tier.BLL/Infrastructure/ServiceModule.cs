using LObject3Tier.DAL.Interfaces;
using LObject3Tier.DAL.Repositories;
using Ninject.Modules;

namespace LObject3Tier.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
