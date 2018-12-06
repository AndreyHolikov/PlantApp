using System;
using PlantApp.DAL.DbContexts;
using PlantApp.DAL.Interfaces;
using PlantApp.DAL.Entities;
using PlantApp.DAL.Repositories.EF;

namespace PlantApp.DAL.Repositories.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private EFPlantContext db;

        private WorkcenterRepository workcenterRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new EFPlantContext(connectionString);
        }


        public IRepository<Workcenter> Workcenters
        {
            get
            {
                if (workcenterRepository == null)
                    workcenterRepository = new WorkcenterRepository(db);
                return workcenterRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
