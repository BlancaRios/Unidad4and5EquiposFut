using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unidad4and5EquiposFut.Areas.Admin.Models;
using Unidad4and5EquiposFut.Models;

namespace Unidad4and5EquiposFut.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class IntegranteController : Controller
    {
        public equiposContext Context { get; }
        public IWebHostEnvironment Host { get; }
        public IntegranteController(equiposContext context, IWebHostEnvironment host)
        {
            Context = context;
            Host = host;
        }
        public IActionResult Index()
        {
            var i = Context.Integrantes.OrderBy(x => x.Nombre);
            return View(i);
        }

        public IActionResult Agregar()
        {
            return View(new CrudIntegranteViewModel
            {
                Equipos = Context.Equipos.OrderBy(x => x.Nombre)
            });
        }
        [HttpPost]
        public IActionResult Agregar(CrudIntegranteViewModel e, IFormFile foto)
        {
            if (Context.Integrantes.Any(x => x.Nombre == e.Integrantes.Nombre))
            {

                ModelState.AddModelError("", "El nombre del integrante ya está en existencia");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);

            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Nombre))
            {
                ModelState.AddModelError("", "El nombre del equipo está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Genero))
            {
                ModelState.AddModelError("", "El Género del integrante está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Edad<=17 ||e.Integrantes.Edad>=50)
            {
                ModelState.AddModelError("", "La edad del integrante debe ser mayor a 18 años pero menor a 50");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.NumCamiseta<=0 || e.Integrantes.NumCamiseta>=12)
            {
                ModelState.AddModelError("", "El número de camiseta del integrante debe ser entre 1 y 11");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Posicion))
            {
                ModelState.AddModelError("", "La posición está vacía");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);

            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Estado))
            {
                ModelState.AddModelError("", "El estado está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Aceleracion<=0 || e.Integrantes.Aceleracion>=11)
            {
                ModelState.AddModelError("", "La aceleración debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Agilidad <= 0 || e.Integrantes.Agilidad >= 11)
            {
                ModelState.AddModelError("", "La agilidad debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Aceleracion <= 0 || e.Integrantes.Aceleracion >= 11)
            {
                ModelState.AddModelError("", "La aceleración debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Salto <= 0 || e.Integrantes.Salto >= 11)
            {
                ModelState.AddModelError("", "El salto debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.ControlDeBalon <= 0 || e.Integrantes.ControlDeBalon >= 11)
            {
                ModelState.AddModelError("", "El contról de balón debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Ofensividad <= 0 || e.Integrantes.Ofensividad >= 11)
            {
                ModelState.AddModelError("", "La ofensividad debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Curva <= 0 || e.Integrantes.Curva >= 11)
            {
                ModelState.AddModelError("", "La curva debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Fuerza <= 0 || e.Integrantes.Fuerza >= 11)
            {
                ModelState.AddModelError("", "La fuerza debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            } 
            if (e.Integrantes.Salario <= 0)
            {
                ModelState.AddModelError("", "El salario debe ser mayor a 0");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }


          

            if (foto != null)
            {
                if (foto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Solo se permite la carga de archivos JPG");
                    e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                    return View(e);
                }
                if (foto.Length > 1024 * 1024 * 5)
                {
                    ModelState.AddModelError("", "No se permite la carga de archivos mayores a 5MB");
                    e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                    return View(e);
                }
            }
            Context.Add(e.Integrantes);
            Context.SaveChanges();
            if (foto != null)
            {
                var path = Host.WebRootPath + "/imgs_integrantes/" + e.Integrantes.Id + "_i.jpg";
                FileStream fs = new FileStream(path, FileMode.Create);
                foto.CopyTo(fs);
                fs.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Modificar(int id)
        {
            Integrante i = Context.Integrantes.FirstOrDefault(x => x.Id == id);
            if (i == null)
            {
                return RedirectToAction("Index");
            }

            return View(new CrudIntegranteViewModel
            {
                Equipos = Context.Equipos.OrderBy(x => x.Nombre),
                Integrantes = i
            }
            ) ;
        }
        [HttpPost]
        public IActionResult Modificar(CrudIntegranteViewModel e, IFormFile foto)
        {
            var integranteAeditar = Context.Integrantes.FirstOrDefault(x => x.Id == e.Integrantes.Id);
            if (integranteAeditar == null)
            {
                return RedirectToAction("Index");
            }
            if (Context.Integrantes.Any(x => x.Nombre == e.Integrantes.Nombre&&x.Id!=e.Integrantes.Id))
            {

                ModelState.AddModelError("", "El nombre del integrante ya está en existencia");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);

            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Nombre))
            {
                ModelState.AddModelError("", "El nombre del equipo está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Genero))
            {
                ModelState.AddModelError("", "El Género del integrante está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Edad <= 17 || e.Integrantes.Edad >= 50)
            {
                ModelState.AddModelError("", "La edad del integrante debe ser mayor a 18 años pero menor a 50");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.NumCamiseta <= 0 || e.Integrantes.NumCamiseta >= 12)
            {
                ModelState.AddModelError("", "El número de camiseta del integrante debe ser entre 1 y 11");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Posicion))
            {
                ModelState.AddModelError("", "La posición está vacía");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);

            }
            if (string.IsNullOrWhiteSpace(e.Integrantes.Estado))
            {
                ModelState.AddModelError("", "El estado está vacío");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Aceleracion <= 0 || e.Integrantes.Aceleracion >= 11)
            {
                ModelState.AddModelError("", "La aceleración debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Agilidad <= 0 || e.Integrantes.Agilidad >= 11)
            {
                ModelState.AddModelError("", "La agilidad debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Aceleracion <= 0 || e.Integrantes.Aceleracion >= 11)
            {
                ModelState.AddModelError("", "La aceleración debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Salto <= 0 || e.Integrantes.Salto >= 11)
            {
                ModelState.AddModelError("", "El salto debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.ControlDeBalon <= 0 || e.Integrantes.ControlDeBalon >= 11)
            {
                ModelState.AddModelError("", "El contról de balón debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Ofensividad <= 0 || e.Integrantes.Ofensividad >= 11)
            {
                ModelState.AddModelError("", "La ofensividad debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Curva <= 0 || e.Integrantes.Curva >= 11)
            {
                ModelState.AddModelError("", "La curva debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Fuerza <= 0 || e.Integrantes.Fuerza >= 11)
            {
                ModelState.AddModelError("", "La fuerza debe ser entre 1 y 10");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }
            if (e.Integrantes.Salario <= 0)
            {
                ModelState.AddModelError("", "El salario debe ser mayor a 0");
                e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                return View(e);
            }




            if (foto != null)
            {
                if (foto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Solo se permite la carga de archivos JPG");
                    e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                    return View(e);
                }
                if (foto.Length > 1024 * 1024 * 5)
                {
                    ModelState.AddModelError("", "No se permite la carga de archivos mayores a 5MB");
                    e.Equipos = Context.Equipos.OrderBy(x => x.Nombre);
                    return View(e);
                }
            }
            integranteAeditar.Nombre = e.Integrantes.Nombre;
            integranteAeditar.Genero = e.Integrantes.Genero;
            integranteAeditar.Edad = e.Integrantes.Edad;
            integranteAeditar.NumCamiseta = e.Integrantes.NumCamiseta;
            integranteAeditar.Posicion = e.Integrantes.Posicion;
            integranteAeditar.Estado = e.Integrantes.Estado;
            integranteAeditar.Aceleracion = e.Integrantes.Aceleracion;
            integranteAeditar.Agilidad = e.Integrantes.Agilidad;
            integranteAeditar.Salto = e.Integrantes.Salto;
            integranteAeditar.ControlDeBalon = e.Integrantes.ControlDeBalon;
            integranteAeditar.Ofensividad = e.Integrantes.Ofensividad;
            integranteAeditar.Curva = e.Integrantes.Curva;
            integranteAeditar.Fuerza = e.Integrantes.Fuerza;
            integranteAeditar.Salario = e.Integrantes.Salario;

            Context.Update(integranteAeditar);
            Context.SaveChanges();
            if (foto != null)
            {
                var path = Host.WebRootPath + "/imgs_integrantes/" + e.Integrantes.Id + "_i.jpg";
                FileStream fs = new FileStream(path, FileMode.Create);
                foto.CopyTo(fs);
                fs.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Integrante i = Context.Integrantes.FirstOrDefault(x => x.Id == id);
            if (i == null)
            {
                return RedirectToAction("Index");
            }

            return View(i);
        }
        [HttpPost]
        public IActionResult Eliminar(Integrante vm)
        {
            var e = Context.Integrantes.FirstOrDefault(x => x.Id == vm.Id);

            if (e == null)
            {
                ModelState.AddModelError("", "No se encontro el equipo, puede que no exista o ya haya sido eliminado");
                return View(e);
            }
          
            Context.Remove(e);

            Context.SaveChanges();
            string path = Host.WebRootPath + "/imgs_integrantes/" + e.Id + "_i.jpg";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }


    }
}
