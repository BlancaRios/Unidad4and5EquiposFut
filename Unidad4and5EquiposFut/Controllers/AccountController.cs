﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Unidad4and5EquiposFut.Models;

namespace Unidad4and5EquiposFut.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(equiposContext context)
        {
            Context = context;
        }

        public equiposContext Context { get; }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var hash = Helpers.Cifrado.GetHash(password);

            var user = Context.Usuarios.SingleOrDefault(x => x.NombreUsuario == username && x.Contraseña == hash);
            if (user != null)
            {  //si encontre el usuario en la bd
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.NombreUsuario));
                claims.Add(new Claim(ClaimTypes.Role, user.Rol));
                claims.Add(new Claim("Id", user.Id.ToString()));

                var identidad = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(identidad));

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña son incorrectos");
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public string AccessDenied()
        {
            return "Acceso denegado";
        }
    }
}
