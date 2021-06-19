using System;
using System.Collections.Generic;
using FrontEndOLS.Models;
using System.Linq;
using System.Threading.Tasks;
using FrontEndOLS.Clases;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndOLS.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {

            CsClientes csClientes = new CsClientes();

            List<Clientes> Clientes = new List<Clientes>();
            Clientes = csClientes.GetClientes();
            ViewBag.Clientes = Clientes;
            return View();
        }
    }
}
