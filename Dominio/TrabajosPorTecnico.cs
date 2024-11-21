using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TrabajosPorTecnico
    {
        public string CodTecnico { get; set; }
        public int IdTrabajo { get; set; }
        public string NombreTrabajo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

    }
}
