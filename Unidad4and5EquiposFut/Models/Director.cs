using System;
using System.Collections.Generic;

#nullable disable

namespace Unidad4and5EquiposFut.Models
{
    public partial class Director
    {
        public Director()
        {
            Equipos = new HashSet<Equipo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int AñosActivo { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
