using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EquiposController : Controller
    {
        public equiposContext Context { get; }
        public IWebHostEnvironment Host { get; }
        public EquiposController(equiposContext context, IWebHostEnvironment host)
        {
            Context = context;
            Host = host;
        }
        [HttpGet]

        public IActionResult Index()
        {
            IEnumerable<Equipo> r = Context.Equipos.OrderBy(x => x.Nombre);
            return View(r);
        }
        [HttpGet]

        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Agregar(CrudEquipsViewModel e, IFormFile foto)
        {
            if (Context.Equipos.Any(x=>x.Nombre==e.Equipos.Nombre))
            {

                ModelState.AddModelError("", "El nombre del equipo ya está en existencia");

                return View(e);

            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Nombre))
            {
                ModelState.AddModelError("", "El nombre del equipo está vacío");
               
                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Pais))
            {
                ModelState.AddModelError("", "El país del equipo está vacío");

                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Descripcion))
            {
                ModelState.AddModelError("", "La descripción del equipo está vacío");

                return View(e);
            }
            
            if (foto != null)
            {
                if (foto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Solo se permite la carga de archivos JPG");
                   
                    return View(e);
                }
                if (foto.Length > 1024 * 1024 * 5)
                {
                    ModelState.AddModelError("", "No se permite la carga de archivos mayores a 5MB");
                   
                    return View(e);
                }
            }
            Context.Add(e.Equipos);
            Context.SaveChanges();
            if (foto != null)
            {
                var path = Host.WebRootPath + "/imgs_equipos/" + e.Equipos.Id + "_e.jpg";
                FileStream fs = new FileStream(path, FileMode.Create);
                foto.CopyTo(fs);
                fs.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Modificar(int id)
        {
            Equipo e = Context.Equipos.FirstOrDefault(x => x.Id == id);
            if (e==null)
            {
                return RedirectToAction("Index");
            }

            return View(new CrudEquipsViewModel
            {
                Equipos=e
            }
            );
        }
        [HttpPost]
        public IActionResult Modificar(CrudEquipsViewModel e, IFormFile foto)
        {
            var equipoAEditar = Context.Equipos.FirstOrDefault(x => x.Id == e.Equipos.Id);
            if (equipoAEditar == null)
            {
                return RedirectToAction("Index");
            }
            if (Context.Equipos.Any(x=>x.Nombre==e.Equipos.Nombre && x.Id != e.Equipos.Id))
            {
                ModelState.AddModelError("", "El nombre del equipo ya está en existencia");

                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Nombre))
            {
                ModelState.AddModelError("", "El nombre del equipo está vacío");

                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Pais))
            {
                ModelState.AddModelError("", "El país del equipo está vacío");

                return View(e);
            }
            if (string.IsNullOrWhiteSpace(e.Equipos.Descripcion))
            {
                ModelState.AddModelError("", "La descripción del equipo está vacío");

                return View(e);
            }

            if (foto != null)
            {
                if (foto.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("", "Solo se permite la carga de archivos JPG");

                    return View(e);
                }
                if (foto.Length > 1024 * 1024 * 5)
                {
                    ModelState.AddModelError("", "No se permite la carga de archivos mayores a 5MB");

                    return View(e);
                }
            }
            equipoAEditar.Nombre = e.Equipos.Nombre;
            equipoAEditar.Pais = e.Equipos.Pais;
            equipoAEditar.Descripcion = e.Equipos.Descripcion;
            
            Context.Update(equipoAEditar);
            Context.SaveChanges();
            if (foto != null)
            {
                var path = Host.WebRootPath + "/imgs_equipos/" + e.Equipos.Id + "_e.jpg";
                FileStream fs = new FileStream(path, FileMode.Create);
                foto.CopyTo(fs);
                fs.Close();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Eliminar(int id)
        {
            Equipo e = Context.Equipos.FirstOrDefault(x => x.Id == id);
            if (e == null)
            {
                return RedirectToAction("Index");
            }
            return View(e);
           
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Eliminar(Equipo vm)
        {
            var e = Context.Equipos.Include(x=>x.Integrantes).FirstOrDefault(x => x.Id == vm.Id);
          
            if (e == null)
            {
                ModelState.AddModelError("", "No se encontro el equipo, puede que no exista o ya haya sido eliminado");
                return View(e);
            }
            if (e!=null)
            {
                if (e.Integrantes.Count()!=0)
                {
                    foreach (var i in e.Integrantes)
                    {
                        Context.Remove(i);
                    }
                }
                Context.Remove(e);

                Context.SaveChanges();
            }
           

            string path = Host.WebRootPath + "/imgs_equipos/" + e.Id + "_e.jpg";
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index");
        }
    }
}
