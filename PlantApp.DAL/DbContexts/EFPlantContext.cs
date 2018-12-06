using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PlantApp.DAL.Entities;

namespace PlantApp.DAL.DbContexts
{
    public class EFPlantContext : DbContext
    {
        public DbSet<Workcenter> Workcenters { get; set; }

        static EFPlantContext()
        {
            Database.SetInitializer<EFPlantContext>(new PlantDbInitializer());
        }
        public EFPlantContext(string connectionString)
            :base(connectionString)
        {

        }
    }

    public class PlantDbInitializer : DropCreateDatabaseAlways<EFPlantContext>
        //: DropCreateDatabaseIfModelChanges<EFPlantContext>
    {
        protected override void Seed(EFPlantContext db)
        {
            #region Add Workcenter 

            var workcenter_dal = new Workcenter { Name = "PlantApp.DAL.UI" };
            var workcenter_bll = new Workcenter { Name = "BLL" };
            var workcenter_web = new Workcenter { Name = "Web" };
            var workcenter_ui = new Workcenter { Name = "UI" };
            db.Workcenters.AddRange(new Workcenter[] { workcenter_ui, workcenter_web, workcenter_bll, workcenter_dal });


            #endregion
        }
    }
}
