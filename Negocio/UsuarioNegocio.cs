using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Management;
using Dominio;  

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usr) {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Usuario, Password, NivelRol from USUARIOS where Usuario = @user AND Password = @pass");
                datos.setearParametro("@user", usr.usuario);
                datos.setearParametro("@pass", usr.password);

                datos.ejecutarLectura();
                while (datos.Lector.Read()) {

                    usr.id = (int)datos.Lector["Id"];
                    switch ((int)(datos.Lector["NivelRol"]))
                    {
                        case 1:
                            usr.nivelRol = NivelRol.ADMINISTRADOR;
                            break;
                        case 2:
                            usr.nivelRol = NivelRol.GERENTE;
                            break;
                        case 3:
                            usr.nivelRol = NivelRol.TECNICO;
                            break;
                        case 4:
                            usr.nivelRol = NivelRol.RECEPCIONISTA;
                            break;
                    }
                    usr.usuario = (string)datos.Lector["Usuario"];
                    usr.password = (string)datos.Lector["Password"];
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { 
                datos.cerrarConexion();
            }

        } 

    }
}
