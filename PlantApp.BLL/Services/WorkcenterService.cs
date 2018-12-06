using System;
using PlantApp.BLL.DTO;
using PlantApp.DAL.Entities;
using PlantApp.BLL.BusinessModels;
using PlantApp.DAL.Interfaces;
using PlantApp.BLL.Infrastructure;
using PlantApp.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using PlantApp.BLL.Util;

namespace PlantApp.BLL.Services
{
    public class WorkcenterService : IService<WorkcenterDTO>
    {
        IUnitOfWork unitOfWork { get; set; }

        public WorkcenterService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<WorkcenterDTO> GetAll()
        {
            IEnumerable<Workcenter> workcenters = this.unitOfWork.Workcenters.GetAll();
            return AutoMapperBllUtil.IEnumerableWorkcenterEntitiesToDto(workcenters);
        }

        public WorkcenterDTO Get(int id)
        {
            var workcenter = this.unitOfWork.Workcenters.Get(id);
            if (workcenter == null)
                throw new ValidationException("Workcenter not found.");

            return new WorkcenterDTO { Id = workcenter.Id, Name = workcenter.Name};
        }

        public int Add(WorkcenterDTO workcenterDto)
        {
            if (workcenterDto == null)
                throw new ValidationException("Workcenter not found.");

            Workcenter workcenter = new Workcenter
            {
                Name = workcenterDto.Name
            };
            int id = this.unitOfWork.Workcenters.Create(workcenter);
            this.unitOfWork.Save();

            return id;
        }

        public void Edit(WorkcenterDTO workcenterDto)
        {
            if (workcenterDto == null || workcenterDto.Id == 0 )
                throw new ValidationException("Workcenter not found.");

            Workcenter workcenter = this.unitOfWork.Workcenters.Get(workcenterDto.Id);

            workcenter = AutoMapperBllUtil.WorkcenterDtoToEntities(workcenterDto);

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
