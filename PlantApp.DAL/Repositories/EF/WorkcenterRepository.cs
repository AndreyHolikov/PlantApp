using System;
using System.Collections.Generic;
using System.Linq;
using PlantApp.DAL.Entities;
using PlantApp.DAL.DbContexts;
using PlantApp.DAL.Interfaces;
using System.Data.Entity;

namespace PlantApp.DAL.Repositories.EF
{
    public class WorkcenterRepository: IRepository<Workcenter>
    {
        private EFPlantContext db;

        public WorkcenterRepository(EFPlantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Workcenter> GetAll()
        {
            return db.Workcenters;
        }

        public Workcenter Get(int id)
        {
            return db.Workcenters.Find(id);
        }


        /// <returns>int workcenter.Id</returns>
        public int Create(Workcenter workcenter)
        {
            var addWorkcenterin = db.Workcenters.Add(workcenter);
            return addWorkcenterin.Id;
        }

        public void Update(Workcenter Workcenter)
        {
            db.Entry(Workcenter).State = EntityState.Modified;
        }

        public IEnumerable<Workcenter> Find(Func<Workcenter, Boolean> predicate)
        {
            return db.Workcenters.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Workcenter Workcenter = db.Workcenters.Find(id);
            if (Workcenter != null)
                db.Workcenters.Remove(Workcenter);
        }
    }
}
