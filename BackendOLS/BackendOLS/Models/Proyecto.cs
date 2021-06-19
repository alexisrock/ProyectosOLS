using System;
using System.Collections.Generic;

#nullable disable

namespace BackendOLS.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            DetalleProyecoLenguajes = new HashSet<DetalleProyecoLenguaje>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Idcliente { get; set; }
        public int? Idestado { get; set; }
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechafin { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Cantidadhoras { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual EstadoProyecto IdestadoNavigation { get; set; }
        public virtual ICollection<DetalleProyecoLenguaje> DetalleProyecoLenguajes { get; set; }
    }
}
