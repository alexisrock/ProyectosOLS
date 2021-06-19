using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendOLS.Clases;
using BackendOLS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackendOLS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        private readonly proyectosClienteContext _context = new proyectosClienteContext();

        [HttpGet("GetAll")]
        public dynamic Proyectos() {

            CsProyecto csProyecto = new CsProyecto();
            return csProyecto.proyectos();

        }

        [HttpGet("GetById/{id}")]
        public dynamic proyectoById(int id) {
            CsProyecto csProyecto = new CsProyecto();
            return csProyecto.proyectoById(id);
        }


        [HttpPost("Create")]
        public Response createProyecto(ObjProyecto objProyecto) {

            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction())
            {
                try
                {
                    CsProyecto csProyecto = new CsProyecto();
                    CsDetalleProyectoLenguaje csDetalleProyectoLenguaje = new CsDetalleProyectoLenguaje();
                    Proyecto proyecto = new Proyecto();

                    proyecto = csProyecto.createProyecto(objProyecto);
                    response = csDetalleProyectoLenguaje.createDetalle(proyecto, objProyecto);

                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al eliminar el Proyecto!, error: " + ex.Message;
                    return response;
                }
            }


        }



        [HttpPut("Update/{id}")]
        public Response updateProyecto(int id, ObjProyecto objProyecto)
        {

            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction())
            {
                try
                {
                    CsProyecto csProyecto = new CsProyecto();
                    CsDetalleProyectoLenguaje csDetalleProyectoLenguaje = new CsDetalleProyectoLenguaje();
                    Proyecto proyecto = new Proyecto();
                    proyecto = csProyecto.updateProyecto(id, objProyecto);
                    response = csDetalleProyectoLenguaje.updateDetalle(proyecto, objProyecto);

                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al eliminar el Proyecto!, error: " + ex.Message;
                    return response;
                }
            }
        }


        [HttpDelete("Delete/{id}")]
        public Response deleleProyecto(int id) {

            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction())
            {
                try
                {
                    CsProyecto csProyecto = new CsProyecto();
                    CsDetalleProyectoLenguaje csDetalleProyectoLenguaje = new CsDetalleProyectoLenguaje();

                    if (csDetalleProyectoLenguaje.deleteDetalle(id))
                    {

                        response = csProyecto.deleteProyecto(id);

                    }
                    else {
                        response.code = "03";
                        response.mensaje = "Id proyecto no encontrado";

                    }
                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al eliminar el Proyecto!, error: " + ex.Message;
                    return response;
                }
            }


        }



    }
}
