using BackendOLS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class CsDetalleProyectoLenguaje
    {
        private readonly proyectosClienteContext _context = new proyectosClienteContext();
        public Response createDetalle(Proyecto  proyecto,  ObjProyecto objProyecto) {
            Response response = new Response();
            foreach (var item in objProyecto.lenguajes)
            {
                DetalleProyecoLenguaje detalleProyecoLenguaje = new DetalleProyecoLenguaje();
                detalleProyecoLenguaje.Idproyecto = proyecto.Id;
                detalleProyecoLenguaje.Idlenguaje = item.idLengaje;
                detalleProyecoLenguaje.Idnivel = item.idnivel;
                _context.DetalleProyecoLenguajes.Add(detalleProyecoLenguaje);
                _context.SaveChanges();
            }
       
            response.code = "01";
            response.mensaje = "Proyecto guardado con exito";
            return response;

        }

        public Response updateDetalle(Proyecto proyecto, ObjProyecto objProyecto)
        {
            Response response = new Response();

            if (proyecto!=null) {
                var detalleslist = _context.DetalleProyecoLenguajes.Where(x => x.Idproyecto == proyecto.Id).ToList();
                foreach (var item in detalleslist)
                {
                    _context.DetalleProyecoLenguajes.Remove(item);
                    _context.SaveChanges();
                }

                foreach (var item in objProyecto.lenguajes)
                {
                    DetalleProyecoLenguaje detalleProyecoLenguaje = new DetalleProyecoLenguaje();
                    detalleProyecoLenguaje.Idproyecto = proyecto.Id;
                    detalleProyecoLenguaje.Idlenguaje = item.idLengaje;
                    detalleProyecoLenguaje.Idnivel = item.idnivel;
                    _context.DetalleProyecoLenguajes.Add(detalleProyecoLenguaje);
                    _context.SaveChanges();
                }
                response.code = "01";
                response.mensaje = "Proyecto guardado con exito";
            } else
            {
                response.code = "03";
                response.mensaje = "Id proyecto no encontrado";
            }



          
            return response;

        }


        public bool deleteDetalle(int id)
        {
            var detalleslist = _context.DetalleProyecoLenguajes.Where(x => x.Idproyecto == id).ToList();
            if (detalleslist != null)
            {
                foreach (var item in detalleslist)
                {
                    _context.DetalleProyecoLenguajes.Remove(item);
                    _context.SaveChanges();
                }
                return true;
            }
            else {
                return false;            
            }              

        }



    }
}
