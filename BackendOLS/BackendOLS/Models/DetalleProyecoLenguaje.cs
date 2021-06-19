using System;
using System.Collections.Generic;

#nullable disable

namespace BackendOLS.Models
{
    public partial class DetalleProyecoLenguaje
    {
        public int Id { get; set; }
        public int? Idproyecto { get; set; }
        public int? Idlenguaje { get; set; }
        public int? Idnivel { get; set; }

        public virtual LenguajesProgramacion IdlenguajeNavigation { get; set; }
        public virtual Nivellenguaje IdnivelNavigation { get; set; }
        public virtual Proyecto IdproyectoNavigation { get; set; }
    }
}
