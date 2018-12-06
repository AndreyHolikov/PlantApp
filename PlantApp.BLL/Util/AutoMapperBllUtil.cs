using AutoMapper;
using PlantApp.BLL.DTO;
using PlantApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantApp.BLL.Util
{
    public static class AutoMapperBllUtil
    {
        /// <summary>
        /// mapper.Map<IEnumerable<Workcenter>, List<WorkcenterDTO>>(workcenters)
        /// </summary>
        public static List<WorkcenterDTO> IEnumerableWorkcenterEntitiesToDto(IEnumerable<Workcenter> workcenters)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Workcenter, WorkcenterDTO>()
                .ForMember("Id", opt => opt.MapFrom(c => c.Id))
                .ForMember("Name", opt => opt.MapFrom(c => c.Name))).CreateMapper();
            return mapper.Map<IEnumerable<Workcenter>, List<WorkcenterDTO>>(workcenters);
        }
        
        public static Workcenter WorkcenterDtoToEntities(WorkcenterDTO workcenterDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkcenterDTO, Workcenter>()).CreateMapper();
            return mapper.Map<WorkcenterDTO, Workcenter>(workcenterDTO);
        }

        public static WorkcenterDTO WorkcenterEntitiesToDto(Workcenter workcenter)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Workcenter, WorkcenterDTO>()).CreateMapper();
            return mapper.Map<Workcenter, WorkcenterDTO>(workcenter);
        }
    }
}