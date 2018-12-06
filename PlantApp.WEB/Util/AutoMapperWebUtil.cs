using AutoMapper;
using PlantApp.BLL.DTO;
using PlantApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantApp.WEB.Util
{
    public static class AutoMapperWebUtil
    {
        /// <summary>
        /// mapper.Map<IEnumerable<WorkcenterDTO>, List<WorkcenterViewModel>>
        /// </summary>
        public static List<WorkcenterViewModel> IEnumerableWorkcenterDtoToVM(IEnumerable<WorkcenterDTO> workcenterDtos)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkcenterDTO, WorkcenterViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<WorkcenterDTO>, List<WorkcenterViewModel>>(workcenterDtos);
        }

        /// <summary>
        /// mapper.Map<WorkcenterViewModel, WorkcenterDTO>
        /// </summary>
        public static WorkcenterDTO WorkcenterVmToDto(WorkcenterViewModel workcenterViewModel)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkcenterViewModel, WorkcenterDTO>()).CreateMapper();
            return mapper.Map<WorkcenterViewModel, WorkcenterDTO>(workcenterViewModel);
        }

        /// <summary>
        /// mapper.Map<WorkcenterDTO, WorkcenterViewModel>
        /// </summary>
        public static WorkcenterViewModel WorkcenterDtoToVm(WorkcenterDTO workcenterDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<WorkcenterDTO, WorkcenterViewModel>()).CreateMapper();
            return mapper.Map<WorkcenterDTO, WorkcenterViewModel>(workcenterDTO);
        }
    }
}