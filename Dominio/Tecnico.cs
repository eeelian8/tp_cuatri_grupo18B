using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Tecnico
    {
        public int Id { get; }
        public string CodTecnico { get; set; }
        public int NivelRol { get; set; }
        public int Celular { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int NroDocumento { get; set; }
        public string ImgUrl { get; set; }
    }
}
