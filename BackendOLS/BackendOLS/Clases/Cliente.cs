using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class OBjCliente
    {

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }



    public class Response {


        public string code { get; set; }
        public string mensaje { get; set; }

    }
}



