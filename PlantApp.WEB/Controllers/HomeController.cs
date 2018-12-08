using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantApp.BLL.Interfaces;
using PlantApp.WEB.Models;
using AutoMapper;
using PlantApp.DAL.Entities;
using PlantApp.WEB.DTO;

// TODO List

// ToDo: Дописать UI React Create Workcenter 1
// ToDo: Дописать UI React Edit Workcenter 1
// ToDo: Дописать UI React Del Workcenter 1

// ToDo: WorkcenterRepository для Dapper 1
// ToDo: UnitOfWork для Dapper 1

// ToDo: Дописать UI React CRUD TASK 4
// ToDo: Дописать WBD CRUD TASK 4

// ToDo: Настроить авторизацию и аутентификацию.
// ToDo: Проверить соответствие проекта и ТЗ
// ToDo: Дописать недостающие тесты
// ToDo: Провести рефакторинг кода
// ToDo: Провести Code Review

namespace PlantApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        ICrudService<Workcenter> workcenterService;

        public HomeController(ICrudService<Workcenter> workcenter)
        {
            workcenterService = workcenter;
        }

        public ActionResult Index()
        {  
            IEnumerable<Workcenter> workcenters = workcenterService.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Workcenter, WorkcenterDTO>()).CreateMapper();
            var workcenterDtos = mapper.Map<IEnumerable<Workcenter>, List<WorkcenterDTO>>(workcenters);
            return View(workcenterDtos);
        }

        protected override void Dispose(bool disposing)
        {
            workcenterService.Dispose();
            base.Dispose(disposing);
        }

        #region Workcenter for test

        class TestWorkcenter
        {
            public string Id { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }

        static List<TestWorkcenter> data = new List<TestWorkcenter>
        {
            new TestWorkcenter { id = 0, name = "TestWorkcenter.UI"},
            new TestWorkcenter { id = 1, name = "TestWorkcenter.WEB"},
            new TestWorkcenter { id = 2, name = "TestWorkcenter.BLL"},
            new TestWorkcenter { id = 3, name = "TestWorkcenter.DAL"}
        };


        public ActionResult GetTestWorkcenters()
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult AddPhone(Workcenter workcenter)
        //{
        //    workcenter.Id = Guid.NewGuid().ToString();
        //    data.Add(workcenter);
        //    return Json(workcenter);
        //}

        #endregion
    }
}