using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Cancha
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string barrio { get; set; }
        
        [Required(ErrorMessage = "Campo obligatorio")]
        public string calle { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int telefono { get; set; }
    }
}