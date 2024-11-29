using Data_Management;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio
{
    public class TipoTrabajoNegocio
    {
        public List<TipoTrabajo> Listar()
        {
            List<TipoTrabajo> lista = new List<TipoTrabajo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre FROM TIPOS_TRABAJO");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoTrabajo aux = new TipoTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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