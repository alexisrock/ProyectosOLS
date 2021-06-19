using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndOLS.Models
{
    public class Proyectos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public int idestado { get; set; }
        public string estado { get; set; }
        public string fechainicio { get; set; }
        public string fechafin { get; set; }
        public int precio { get; set; }
        public int cantidadhoras { get; set; }

    }
}
