using Ninject.Modules;
using PlantApp.BLL.Services;
using PlantApp.BLL.Interfaces;
using PlantApp.BLL.DTO;

namespace PlantApp.WEB.Util
{
    public class WorkcenterModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<WorkcenterDTO>>().To<WorkcenterService>();
        }
    }
}