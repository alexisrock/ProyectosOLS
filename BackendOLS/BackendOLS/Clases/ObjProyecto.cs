using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class ObjProyecto
    {

        public string nombre { get; set; }
        public int idcliente { get; set; }
        public int idestado { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int precio  { get; set; }
        public int cantidadHoras { get; set; }

        public List<ObjLenguajes> lenguajes { get; set; }

    }


    public class ObjLenguajes {

        public int idLengaje { get; set; }
        public int idnivel { get; set; }


    }
}
