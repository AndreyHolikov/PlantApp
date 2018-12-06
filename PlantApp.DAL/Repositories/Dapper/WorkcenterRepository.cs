using System;
using System.Collections.Generic;
using System.Linq;
using PlantApp.DAL.Entities;
using PlantApp.DAL.DbContexts;
using PlantApp.DAL.Interfaces;


namespace PlantApp.DAL.Repositories.Daper
{
    public class WorkcenterRepository: IRepository<Workcenter>
    {
        //private DapperPlantContext db;

        public int Create(Workcenter item)
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-Create
        }

        public void Delete(int id)
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-Delete
        }

        public IEnumerable<Workcenter> Find(Func<Workcenter, bool> predicate)
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-Find
        }

        public Workcenter Get(int id)
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-Get
        }

        public IEnumerable<Workcenter> GetAll()
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-GetAll
        }

        public void Update(Workcenter item)
        {
            throw new NotImplementedException(); //Todo: Create: DapperPlantContext-Update
        }
    }
}
