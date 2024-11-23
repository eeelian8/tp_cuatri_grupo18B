using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoTrabajo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int DuracionCantDias { get; set; }

        // Sobreescribir ToString para mostrar el nombre en el DropDownList
        public override string ToString()
        {
            return Nombre;
        }
    }
}
