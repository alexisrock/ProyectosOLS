using BackendOLS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class CsProyecto
    {
        private readonly proyectosClienteContext _context = new proyectosClienteContext();


        public dynamic proyectos() {
            var proyectos = _context.Proyectos.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Idcliente,
                Cliente = x.IdclienteNavigation.Nombres + " " + x.IdclienteNavigation.Apellidos,
                x.Idestado,
                Estado = x.IdestadoNavigation.Descripcion,
                fechainicio = x.Fechainicio.Value.ToString("yyyy/MM/dd"),
                fechafin = x.Fechafin.Value.ToString("yyyy/MM/dd"),
                x.Precio,
                x.Cantidadhoras
            });
            return proyectos;
        }



        public dynamic proyectoById(int id) {
            var proyecto = _context.Proyectos.Select(x => new
            {
                x.Id,
                x.Nombre,
                x.Idcliente,
                x.Idestado,
                fechainicio = x.Fechainicio.Value.ToString("yyyy/MM/dd"),
                fechafin = x.Fechafin.Value.ToString("yyyy/MM/dd"),
                x.Precio,
                x.Cantidadhoras
            }).FirstOrDefault(y => y.Id == id);

            return proyecto;
        }


        public Proyecto createProyecto(ObjProyecto objproyecto) {

            Response response = new Response();
            Proyecto proyecto = new Proyecto();
            proyecto.Nombre = objproyecto.nombre;
            proyecto.Idcliente = objproyecto.idcliente;
            proyecto.Idestado = objproyecto.idestado;
            proyecto.Fechainicio = objproyecto.fechaInicio;
            proyecto.Fechafin = objproyecto.fechaFin;
            proyecto.Precio = objproyecto.precio;
            proyecto.Cantidadhoras = objproyecto.cantidadHoras;
            _context.Proyectos.Add(proyecto);
            _context.SaveChanges();       
            return proyecto;
        }

        public Proyecto updateProyecto(int id, ObjProyecto objproyecto)
        {

            Response response = new Response();
            var proyecto = _context.Proyectos.FirstOrDefault(x=>x.Id==id);
            if (proyecto!=null)
            {
                proyecto.Nombre = objproyecto.nombre;
                proyecto.Idcliente = objproyecto.idcliente;
                proyecto.Idestado = objproyecto.idestado;
                proyecto.Fechainicio = objproyecto.fechaInicio;
                proyecto.Fechafin = objproyecto.fechaFin;
                proyecto.Precio = objproyecto.precio;
                proyecto.Cantidadhoras = objproyecto.cantidadHoras;
                _context.Entry(proyecto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

            }
           
            return proyecto;
        }


        public Response deleteProyecto(int id) {
            Response response = new Response();
            var proyecto = _context.Proyectos.FirstOrDefault(x=> x.Id==id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
                _context.SaveChanges();
                response.code = "01";
                response.mensaje = "Proyecto eliminado con exito";
            }
            return response;
        }




    }
}
