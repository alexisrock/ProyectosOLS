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
    public class ClienteController : ControllerBase
    {
        private readonly proyectosClienteContext _context = new proyectosClienteContext();

        [HttpGet("Getall")]
        public dynamic GetAllCliente() {
            CsCliente Cscliente = new CsCliente();
            return Cscliente.clientes();
        }



        [HttpGet("GetById/{id}")]
        public dynamic getAllCliente(int id)
        {
            CsCliente Cscliente = new CsCliente();
            return Cscliente.clienteById(id);
        }



        [HttpPost("Create")]
        public Response createCliente(OBjCliente objcliente) {
            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction()) {
                try
                {
                    CsCliente cscliente = new CsCliente();
                    response = cscliente.crateCliente(objcliente);
                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al crear el cliente!, error: "+ex.Message;
                    return response;
                }              
            }   
        }


        [HttpPut("Update/{id}")]
        public Response updateCliente(int id, OBjCliente objcliente) {
            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction())
            {
                try
                {
                    CsCliente cscliente = new CsCliente();
                    response = cscliente.updateCliente(id,objcliente);

                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al actulizar el cliente!, error: "+ex.Message;
                    return response;
                }
            }
        }

        [HttpDelete("Delete/{id}")]
        public Response deleteCliente(int id) {
            Response response = new Response();
            using (IDbContextTransaction tn = _context.Database.BeginTransaction())
            {
                try
                {
                    CsCliente cscliente = new CsCliente();
                    response = cscliente.deleteCliente(id);

                    tn.Commit();
                    return response;
                }
                catch (Exception ex)
                {

                    tn.Rollback();
                    response.code = "02";
                    response.mensaje = "Error al eliminar el cliente!, error: "+ex.Message;
                    return response;
                }
            }


        }





    }
}
