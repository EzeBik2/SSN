using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Equipo
    {
        public int id2 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int cantjug { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int calificacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int cantvotos { get; set; }
    }
}