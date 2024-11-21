using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public int nivelRol { get; set; }
        public int NroDocumento { get; set; }

    }
}
