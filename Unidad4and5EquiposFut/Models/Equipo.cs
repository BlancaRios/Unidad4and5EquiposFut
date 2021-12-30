using System;
using System.Collections.Generic;

#nullable disable

namespace Unidad4and5EquiposFut.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Integrantes = new HashSet<Integrante>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Integrante> Integrantes { get; set; }
    }
}
