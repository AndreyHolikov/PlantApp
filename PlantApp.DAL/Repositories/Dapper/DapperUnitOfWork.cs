using System;
using PlantApp.DAL.DbContexts;
using PlantApp.DAL.Interfaces;
using PlantApp.DAL.Entities;

namespace PlantApp.DAL.Repositories.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        public IRepository<Workcenter> Workcenters => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException(); //Todo: Create: DapperUnitOfWork-Dispose
        }

        public void Save()
        {
            throw new NotImplementedException(); //Todo: Create: DapperUnitOfWork-Save
        }
    }
}
