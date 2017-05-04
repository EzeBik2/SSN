using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSF.Models
{
    public class Id
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public int id { get; set; }
    }
}