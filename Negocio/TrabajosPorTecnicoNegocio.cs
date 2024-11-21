using Data_Management;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TrabajosPorTecnicoNegocio
    {
        public List<TrabajosPorTecnico> Listar(string CodTecnico)
        {
            List<TrabajosPorTecnico> lista = new List<TrabajosPorTecnico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ST.TecnicoAsignado, FT.FechaInicio, FT.FechaFin, TT.DuracionCantDias, TT.Nombre as NombreTrabajo, ST.Id as IdSolicitud from SOLICITUDES_TRABAJO as ST inner join FECHAS_TRABAJO as FT on ST.Id = FT.IdSolicitudTrabajo inner join TIPOS_TRABAJO as TT on TT.Id = ST.IdTipoTrabajo where ST.Estado = 1 and ST.TecnicoAsignado != ' ' and ST.TecnicoAsignado = @idTecnico");
                datos.setearParametro("@idTecnico", CodTecnico);
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    TrabajosPorTecnico aux = new TrabajosPorTecnico();
                    aux.IdTrabajo = (int)datos.Lector["IdSolicitud"];
                    aux.NombreTrabajo = (string)datos.Lector["NombreTrabajo"];
                    aux.FechaInicio = (DateTime)datos.Lector["FechaInicio"];
                    aux.FechaFin = (DateTime)datos.Lector["FechaFin"];
                    aux.CodTecnico = (string)datos.Lector["TecnicoAsignado"];

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
