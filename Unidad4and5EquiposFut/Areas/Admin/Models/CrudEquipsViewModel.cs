using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unidad4and5EquiposFut.Models;

namespace Unidad4and5EquiposFut.Areas.Admin.Models
{
    public class CrudEquipsViewModel
    {
        public  Equipo Equipos { get; set; }
        public IEnumerable<Integrante> Integrante { get; set; }
    }
}
