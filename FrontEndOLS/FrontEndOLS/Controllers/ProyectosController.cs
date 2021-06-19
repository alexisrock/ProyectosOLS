using System;
using System.Collections.Generic;
using System.Linq;
using FrontEndOLS.Models;
using System.Threading.Tasks;
using FrontEndOLS.Clases;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndOLS.Controllers
{
    public class ProyectosController : Controller
    {
        public IActionResult Index()
        {

            CsProyectos csProyectos = new CsProyectos();
            List<Proyectos> proyectos = new List<Proyectos>();
            proyectos = csProyectos.GetProyectos();
            ViewBag.Proyectos = proyectos;
            return View();
        }
    }
}
