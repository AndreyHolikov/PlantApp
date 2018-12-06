using Ninject.Modules;
using PlantApp.DAL.Interfaces;
using PlantApp.DAL.Repositories;
using PlantApp.DAL.Repositories.EF;

namespace PlantApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString { get; set; }

        public ServiceModule(string connection) => connectionString = connection;

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
