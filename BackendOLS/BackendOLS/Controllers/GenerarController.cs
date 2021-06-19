using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BackendOLS.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendOLS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerarController : ControllerBase
    {


        [HttpGet("Generar")]
        public Response generarReporte() {
            Response response = new Response();
            try
            {
                CsGenerar csGenerar = new CsGenerar();
                DataTable dataTable = new DataTable();
                dataTable = csGenerar.generarReporte();
                response =  csGenerar.createFile(dataTable);
                return response;
            }
            catch (Exception ex)
            {
                response.code = "02";
                response.mensaje = "Error al crear el Archivo!, error: " + ex.InnerException.Message;
                return response;
            }
        
        
        }



    }
}
