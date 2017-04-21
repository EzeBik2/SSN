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

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug1 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug2 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug3 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug4 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug5 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug6 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug7 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug8 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug9 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug10 { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string idjug11 { get; set; }

        
    }
}