using System;
using PlantApp.DAL.Entities;

namespace PlantApp.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Workcenter> Workcenters { get; }

        void Save();
    }
}
