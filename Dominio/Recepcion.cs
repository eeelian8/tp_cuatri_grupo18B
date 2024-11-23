using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Recepcion
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string CodRecepcionista { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int NivelRol { get; set; }
        public int Celular { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string TipoTrabajo { get; set; }
        public int IdTipoTrabajo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public int NroDocumento { get; set; }

    }
}
