using AutoMapper;
using NLog;
using PlantApp.DAL.Entities;
using PlantApp.WEB.DTO;
using PlantApp.BLL.Infrastructure;
using PlantApp.BLL.Interfaces;
using PlantApp.WEB.Models;
using PlantApp.WEB.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PlantApp.WEB.Controllers
{
    public class WorkcenterController : Controller
    {
        ICrudService<Workcenter> workcenterCrudService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public WorkcenterController(ICrudService<Workcenter> workcenter)
        {
            workcenterCrudService = workcenter;
        }

        
        public JsonResult Index()
        {
            var workcenters = workcenterCrudService.GetAll();
            var workcenterDtos = AutoMapperWebUtil.IEnumerableWorkcenterEntitiesToDto(workcenters);
            return Json(workcenterDtos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add()
        {
            var workcenterDto = new WorkcenterDTO();
            //workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(WorkcenterDTO workcenterDto)
        {
            try
            {
                //workcenterViewModel.ModelState = this.ModelState;
                if (ModelState.IsValid)
                { 
                    var workcenterDTO = AutoMapperWebUtil.WorkcenterDtoToEntities(workcenterDto);
                    int workcenterId = workcenterCrudService.Add(workcenterDTO);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex,  ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            //workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterDto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] 
        public ActionResult Edit(int id)
        {   
            WorkcenterDTO workcenterDto = new WorkcenterDTO();
            try
            {
                Workcenter workcenter = workcenterCrudService.Get(id);
                if (workcenter == null)
                {
                    logger.Error($"HttpNotFound! Url:{System.Web.HttpContext.Current.Request.UrlReferrer}");

                    //Dictionary<string, string> statys = new Dictionary<string, string>
                    //{
                    //    ["statys"] = "HttpNotFound"
                    //};

                    //return Json(statys, JsonRequestBehavior.AllowGet);
                    return HttpNotFound();
                }
                else
                {
                    workcenterDto = AutoMapperWebUtil.WorkcenterEntitiesToDto(workcenter);
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
           // workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterDto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(WorkcenterDTO workcenterDto)
        {
            try
            {
                //workcenterViewModel.ModelState = this.ModelState;
                if (ModelState.IsValid)
                {
                    var workcenter = AutoMapperWebUtil.WorkcenterDtoToEntities(workcenterDto);
                    workcenterCrudService.Edit(workcenter);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
           // workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterDto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            WorkcenterDTO workcenterDto;
            Workcenter workcenter = workcenterCrudService.Get(id);
            try
            {
                if (workcenter == null)
                {
                    return HttpNotFound();
                } else
                {
                    workcenterDto = AutoMapperWebUtil.WorkcenterEntitiesToDto(workcenter);
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            return Json(workcenterDto,JsonRequestBehavior.AllowGet);
        }

        [HttpDelete, ActionName("Delete")]
        public ActionResult DeleteWorkcenter(int id)
        {
            Workcenter workcenter = workcenterCrudService.Get(id);
            try
            {
                if (workcenter != null)
                {
                    workcenterCrudService.Delete(id);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            workcenterCrudService.Dispose();
            base.Dispose(disposing);
        }
    }
}