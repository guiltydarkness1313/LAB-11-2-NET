using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUD_LAB11.Models
{
    public class Employee
    {   
        [Display(Name ="ID")]
        public int id { get; set; }
        [Required(ErrorMessage ="Nombre Requerido")]
        [Display(Name = "Nombre")]
        public string name { get; set; }
        [Required(ErrorMessage = "Ciudad Requerida")]
        [Display(Name = "Ciudad")]
        public string city { get; set; }
        [Required(ErrorMessage = "Dirección Requerida")]
        [Display(Name = "Dirección")]
        public string address { get; set; }

    }
}