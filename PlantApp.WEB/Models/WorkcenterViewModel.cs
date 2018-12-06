using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlantApp.WEB.Models
{
    public class WorkcenterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ModelStateDictionary ModelState { get; set; }
    }
}