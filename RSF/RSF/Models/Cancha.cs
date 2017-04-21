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
        public string id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Barrio { get; set; }
        
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Calle { get; set; }
    }
}