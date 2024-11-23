using Data_Management;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EtapasPorTrabajoNegocio
    {
        public List<EtapasPorTrabajo> ListarPorTrabajo(string tipoDeTrabajo)
        {
            List<EtapasPorTrabajo> lista = new List<EtapasPorTrabajo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ET.Id, TT.Id as IdTipoTrabajo, TT.Nombre, ET.Etapa from ETAPAS_TRABAJO as ET inner join TIPOS_TRABAJO as TT on ET.IdTipoTrabajo = TT.Id where Nombre = @TipoTrabajo");
                datos.setearParametro("TipoTrabajo", tipoDeTrabajo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EtapasPorTrabajo aux = new EtapasPorTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdTipoTrabajo = (int)datos.Lector["IdTipoTrabajo"];
                    aux.Etapa = (string)datos.Lector["Etapa"];
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
