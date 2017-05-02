using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Jugador
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string foto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int edad { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int telefono { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int calificacion { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int cantidaddevotos { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string contraseña { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Confcontraseña { get; set; }
    }
}