using System;
using System.Collections.Generic;

#nullable disable

namespace BackendOLS.Models
{
    public partial class LenguajesProgramacion
    {
        public LenguajesProgramacion()
        {
            DetalleProyecoLenguajes = new HashSet<DetalleProyecoLenguaje>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DetalleProyecoLenguaje> DetalleProyecoLenguajes { get; set; }
    }
}
