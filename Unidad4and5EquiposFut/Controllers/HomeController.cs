using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unidad4and5EquiposFut.Models;

namespace Unidad4and5EquiposFut.Controllers
{
    public class HomeController : Controller
    {
        public equiposContext Context { get; }

        public HomeController(equiposContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("equipos")]
        public IActionResult Equipos()
        {
            var p = Context.Equipos.OrderBy(x => x.Nombre);
            return View(p);
        }
        [Route("equipo/informacion/{nombre}")]
        public IActionResult VerInformacionEquipo(string nombre)
        {
            var e = Context.
                Equipos.Include(x=>x.Integrantes).
                FirstOrDefault(x => x.Nombre == nombre.Replace("-"," "));
            if (e==null)
            {
                
             return RedirectToAction("equipos");
            }
  

            return View(e);
        }
        [Route("integrante/informacion/{nombre}")]
        public IActionResult VerInformacionIntegrante(string nombre)
        {
            var integrante = Context.Integrantes.Include(x=>x.IdEquipoNavigation).FirstOrDefault(x => x.Nombre == nombre.Replace("-"," "));
            //var integrante = Context.
            //    Equipos.Include(x => x.Integrantes).
            //    FirstOrDefault(x => x.Nombre == nombre.Replace("-", " "));
            if (integrante == null)
            {

                return RedirectToAction("equipos");
            }


            return View(integrante);
        }

    }
}
