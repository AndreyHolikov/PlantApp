using System;
using PlantApp.DAL.Entities;
using PlantApp.BLL.BusinessModels;
using PlantApp.DAL.Interfaces;
using PlantApp.BLL.Infrastructure;
using PlantApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
//using PlantApp.BLL.Util;

namespace PlantApp.BLL.Services
{
    public class WorkcenterService : ICrudService<Workcenter>
    {
        IUnitOfWork unitOfWork { get; set; }

        public WorkcenterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Workcenter> GetAll()
        {
            return this.unitOfWork.Workcenters.GetAll();
        }

        public Workcenter Get(int id)
        {
            var workcenter = this.unitOfWork.Workcenters.Get(id);
            if (workcenter == null)
                throw new ValidationException("Workcenter not found.");

            return new Workcenter { Id = workcenter.Id, Name = workcenter.Name};
        }

        public int Add(Workcenter workcenter)
        {
            if (workcenter == null)
                throw new ValidationException("Workcenter not found.");

            int id = this.unitOfWork.Workcenters.Create(workcenter);
            this.unitOfWork.Save();

            return id;
        }

        public void Edit(Workcenter workcenter)
        {
            if (workcenter == null || workcenter.Id == 0 )
                throw new ValidationException("Workcenter not found.");

            var _workcenter = this.unitOfWork.Workcenters.Get(workcenter.Id);
            if (_workcenter == null)
                throw new ValidationException("Workcenter not found.");

            this.unitOfWork.Workcenters.Update(workcenter);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ValidationException("Workcenter not found.");
            this.unitOfWork.Workcenters.Delete(id);
            this.unitOfWork.Save();
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }

    }
}
