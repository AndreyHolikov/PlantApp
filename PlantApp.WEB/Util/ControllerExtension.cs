using NLog;
using PlantApp.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantApp.WEB.Util
{
    public static class ControllerExtension
    {
        public static void ActionsOnException(Logger logger, ValidationException ex, ModelStateDictionary ModelState)
        {
            logger.Error($"Error! ex.Message:{ex.Message}. ex.Property{ex.Property}");
            ModelState.AddModelError(ex.Property, ex.Message);
        }
    }
}