using System;
using System.Collections.Generic;

#nullable disable

namespace Unidad4and5EquiposFut.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}
