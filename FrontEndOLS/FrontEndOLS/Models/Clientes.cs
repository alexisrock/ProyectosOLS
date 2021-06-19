using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndOLS.Models
{
    public class Clientes
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direcion { get; set; }
        public string telefono { get; set; }
    }


    public class listClientes {


        public Array clientes { get; set; }

    }
}
