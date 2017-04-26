using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Equipo
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string cantjug { get; set; }        
    }
}