using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum NivelRol
    {
        ADMINISTRADOR = 1,
        GERENTE = 2,
        TECNICO = 3,
        RECEPCIONISTA = 4
    }
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public NivelRol nivelRol { get; set; }


        public Usuario(string user, string pass, int nivel) { 
            usuario = user;
            password = pass;
            switch (nivel)
            {
                case 1: nivelRol = NivelRol.ADMINISTRADOR;
                    break;
                case 2:
                    nivelRol = NivelRol.GERENTE;
                    break;
                case 3:
                    nivelRol = NivelRol.TECNICO;
                    break;
                case 4: nivelRol = NivelRol.RECEPCIONISTA;
                    break;
            }
        }

    }
}
