using System;
using System.Collections.Generic;

#nullable disable

namespace BackendOLS.Models
{
    public partial class EstadoProyecto
    {
        public EstadoProyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
