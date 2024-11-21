using Data_Management;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TarjetaTecnicosNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<TarjetaTecnicos> ListarTarjetas()
        {
            List<Dominio.TarjetaTecnicos> lista = new List<TarjetaTecnicos>();

            try
            {
                datos.setearConsulta(@"
                SELECT 
                    Id, 
                    Nombre, 
                    CodTenico, 
                    imagenUrl 
                FROM TECNICOS");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new TarjetaTecnicos
                    {
                        Id = (int)datos.Lector["Id"],
                        Titulo = (string)datos.Lector["Nombre"],
                        Descripcion = (string)datos.Lector["CodTecnicos"],
                        ImagenUrl = (string)datos.Lector["imagenUrl"]
                    });
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
