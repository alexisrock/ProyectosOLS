using BackendOLS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class CsCliente
    {
     private readonly   proyectosClienteContext _context = new proyectosClienteContext();


       
        public dynamic clientes() {
            var Clientes = _context.Clientes.Select(x=>new { 
            x.Id,
            x.Nombres,
            x.Apellidos,
            x.Cedula,
            x.Direcion,
            x.Telefono
            }).ToList();
            return Clientes;            
        }


        public dynamic clienteById(int id) {
            var Clientes = _context.Clientes.Select(x => new {
                x.Id,
                x.Nombres,
                x.Apellidos,
                x.Cedula,
                x.Direcion,
                x.Telefono
            }).FirstOrDefault(x=> x.Id==id);
            return Clientes;
        }


        public Response crateCliente(OBjCliente objcliente) {

            Response response = new Response();
            Cliente clientes = new Cliente();
            clientes.Nombres = objcliente.nombres;
            clientes.Apellidos = objcliente.apellidos;
            clientes.Cedula = objcliente.cedula;
            clientes.Direcion = objcliente.direccion;
            clientes.Telefono = objcliente.telefono;
            _context.Clientes.Add(clientes);
            _context.SaveChanges();
            response.code = "01";
            response.mensaje = "Cliente guardado con exito";
            return response;
        }


        public Response updateCliente(int id, OBjCliente objcliente) {


            Response response = new Response();

            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                cliente.Nombres = objcliente.nombres;
                cliente.Apellidos = objcliente.apellidos;
                cliente.Cedula = objcliente.cedula;
                cliente.Direcion = objcliente.direccion;
                cliente.Telefono = objcliente.telefono;
                _context.Entry(cliente).State = EntityState.Modified;
                _context.SaveChanges();
                response.code = "01";
                response.mensaje = "Cliente guardado con exito";
            }
            else {
                response.code = "03";
                response.mensaje = "Id cliente no encontrado";
            }        
          
            return response;
        }



        public Response deleteCliente(int id) {
            Response response = new Response();
            var cliente = _context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                response.code = "01";
                response.mensaje = "Cliente eliminado con exito";
            }
            else {
                response.code = "03";
                response.mensaje = "Id cliente no encontrado";

            }
            return response;
        }

    }
}
