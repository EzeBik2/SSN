using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSF.Models
{
    public class Desafio
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public int idcancha { get; set; }
        public int cantidaddejugadores { get; set; }
        public int idequipo1 { get; set; }
        public int idequipo2 { get; set; }
    }
}