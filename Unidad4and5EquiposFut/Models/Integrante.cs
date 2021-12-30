using System;
using System.Collections.Generic;

#nullable disable

namespace Unidad4and5EquiposFut.Models
{
    public partial class Integrante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public int NumCamiseta { get; set; }
        public string Posicion { get; set; }
        public string Estado { get; set; }
        public int Aceleracion { get; set; }
        public int Agilidad { get; set; }
        public int Salto { get; set; }
        public int ControlDeBalon { get; set; }
        public int Ofensividad { get; set; }
        public int Curva { get; set; }
        public int Fuerza { get; set; }
        public decimal Salario { get; set; }
        public int IdEquipo { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; }
    }
}
