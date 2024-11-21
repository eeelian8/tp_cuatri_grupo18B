using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Data_Management;
using Dominio;  

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(string user, string pass, int nr)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.Id, U.Usuario, U.Password, U.NivelRol from USUARIOS as U where U.Usuario = @user AND U.Password = @pass AND U.NivelRol = @nr");
                datos.setearParametro("@user", user);
                datos.setearParametro("@pass", pass);
                datos.setearParametro("@nr", nr);
                datos.ejecutarLectura();

                int count = 0;
                if (datos.Lector.Read())
                {
                    count = (int)datos.Lector[0];
                }

                if (count > 0)
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return false;
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select usr.Usuario, usr.Password, usr.NroDocumento, usr.NivelRol from USUARIOS as usr");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.usuario = (string)datos.Lector["Usuario"];
                    aux.password = (string)datos.Lector["Password"];
                    aux.NroDocumento = (int)datos.Lector["NroDocumento"];
                    aux.nivelRol = (int)datos.Lector["NivelRol"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
