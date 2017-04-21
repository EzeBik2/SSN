using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string edad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string amigo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Confcontraseña { get; set; }
    }
}