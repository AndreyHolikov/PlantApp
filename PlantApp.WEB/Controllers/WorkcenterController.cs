using AutoMapper;
using NLog;
using PlantApp.BLL.DTO;
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
        IService<WorkcenterDTO> workcenterService;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public WorkcenterController(IService<WorkcenterDTO> workcenter)
        {
            workcenterService = workcenter;
        }

        
        public JsonResult Index()
        {
            var workcenterDtos = workcenterService.GetAll();
            var workcenters = AutoMapperWebUtil.IEnumerableWorkcenterDtoToVM(workcenterDtos);
            return Json(workcenters, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add()
        {
            var workcenterViewModel = new WorkcenterViewModel();
            workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(WorkcenterViewModel workcenterViewModel)
        {
            try
            {
                workcenterViewModel.ModelState = this.ModelState;
                if (ModelState.IsValid)
                { 
                    var workcenterDTO = AutoMapperWebUtil.WorkcenterVmToDto(workcenterViewModel);
                    int workcenterId = workcenterService.Add(workcenterDTO);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex,  ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet] 
        public ActionResult Edit(int id)
        {   
            WorkcenterViewModel workcenterViewModel = new WorkcenterViewModel();
            try
            {
                WorkcenterDTO workcenterDTO = workcenterService.Get(id);
                if (workcenterDTO == null)
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
                    workcenterViewModel = AutoMapperWebUtil.WorkcenterDtoToVm(workcenterDTO);
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(WorkcenterViewModel workcenterViewModel)
        {
            try
            {
                workcenterViewModel.ModelState = this.ModelState;
                if (ModelState.IsValid)
                {
                    var workcenterDTO = AutoMapperWebUtil.WorkcenterVmToDto(workcenterViewModel);
                    workcenterService.Edit(workcenterDTO);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            workcenterViewModel.ModelState = this.ModelState;
            return Json(workcenterViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            WorkcenterViewModel workcenterVM;
            WorkcenterDTO workcenterDTO = workcenterService.Get(id);
            try
            {
                if (workcenterDTO == null)
                {
                    return HttpNotFound();
                } else
                {
                    workcenterVM = AutoMapperWebUtil.WorkcenterDtoToVm(workcenterDTO);
                }
            }
            catch (ValidationException ex)
            {
                ControllerExtension.ActionsOnException(logger, ex, ModelState);
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            return Json(workcenterVM,JsonRequestBehavior.AllowGet);
        }

        [HttpDelete, ActionName("Delete")]
        public ActionResult DeleteWorkcenter(int id)
        {
            WorkcenterDTO workcenterDTO = workcenterService.Get(id);
            try
            {
                if (workcenterDTO != null)
                {
                    workcenterService.Delete(id);
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
            workcenterService.Dispose();
            base.Dispose(disposing);
        }
    }
}