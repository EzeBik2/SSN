using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSF.Models
{
    public class Todos
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public int cantjug { get; set; }

        public int telefono { get; set; }

        public string barrio { get; set; }

        public string calle { get; set; }

        public string tipo { get; set; }

        public DateTime fecha { get; set; }

        public List<string> canchas { get; set; }

        public List<string> equipos { get; set; }
        public List<string> barrios { get; set; }
        public List<string> MisEquipos { get; set; }
        public List<string> NoMisEquipos { get; set; }
    }
}