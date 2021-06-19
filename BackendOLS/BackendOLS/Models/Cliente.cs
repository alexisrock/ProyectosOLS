using System;
using System.Collections.Generic;

#nullable disable

namespace BackendOLS.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direcion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
