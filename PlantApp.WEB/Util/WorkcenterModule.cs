using Ninject.Modules;
using PlantApp.BLL.Services;
using PlantApp.BLL.Interfaces;
using PlantApp.WEB.DTO;
using PlantApp.DAL.Entities;

namespace PlantApp.WEB.Util
{
    public class WorkcenterModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICrudService<Workcenter>>().To<WorkcenterService>();
        }
    }
}