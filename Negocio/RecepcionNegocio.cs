using System.Collections.Generic;
using Data_Management;
using Dominio;
using System;
using System.Net;
using System.Data;

namespace Negocio
{
    public class RecepcionNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public Recepcion GetCliente(string DNI)
        {
            Recepcion cliente = null;
            try
            {
                datos.setearConsulta("SELECT * FROM SOLICITUDES_TRABAJO WHERE DniCliente = @Dni");
                datos.setearParametro("@Dni", DNI);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Recepcion();


                    cliente.Documento = DNI;
                    cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    cliente.Telefono = (int)datos.Lector["TelefonoCliente"];
                    cliente.Direccion = (string)datos.Lector["DireccionCliente"];
                    cliente.Localidad = (string)datos.Lector["LocalidadCliente"];
                    cliente.Provincia = (string)datos.Lector["ProvinciaCliente"];

                }


            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return cliente;
        }


        public List<TipoTrabajo> ListarTipos()
        {
            List<TipoTrabajo> lista = new List<TipoTrabajo>();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, DuracionCantDias FROM TIPOS_TRABAJO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new TipoTrabajo
                    {
                        Id = (int)datos.Lector["Id"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Descripcion = datos.Lector["Descripcion"] != DBNull.Value ? (string)datos.Lector["Descripcion"] : null,
                        DuracionCantDias = (int)datos.Lector["DuracionCantDias"]
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

        public List<Recepcion> Listar()
        {
            List<Recepcion> lista = new List<Recepcion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select rec.CodRecepcionista, rec.NivelRol, rec.Celular, rec.Nombre, rec.Apellido, rec.NroDocumento from RECEPCIONISTAS as rec");
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Recepcion aux = new Recepcion();
                    aux.CodRecepcionista = (string)datos.Lector["CodRecepcionista"];
                    aux.NivelRol = (int)datos.Lector["NivelRol"];
                    aux.Celular = (int)datos.Lector["Celular"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.NroDocumento = (int)datos.Lector["NroDocumento"];

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
        public int Agregar(Recepcion cli)
        {


            try
            {
                datos.limpiarParametros();
                datos.setearConsulta("SELECT COUNT(1) FROM SOLICITUDES_TRABAJO WHERE DniCliente = @Dni");
                datos.setearParametro("@Dni", cli.Documento);
                datos.ejecutarLectura();
               
                datos.cerrarConexion();
                datos.limpiarParametros();

                datos.setearConsulta("INSERT INTO SOLICITUDES_TRABAJO (DniCliente, NombreCliente, ApellidoCliente, DescripcionTrabajo, TelefonoCliente, DireccionCliente, LocalidadCliente, ProvinciaCliente,IdTipoTrabajo,  Estado) VALUES (@Dni, @Nombre, @Apellido, @Descripcion, @Telefono, @Direccion, @Localidad, @Provincia, @TipoTrabajo, @Estado)");
                datos.setearParametro("@Dni", cli.Documento);
                datos.setearParametro("@Nombre", cli.Nombre);
                datos.setearParametro("@Apellido", cli.Apellido);
                datos.setearParametro("@Descripcion", cli.Descripcion);
                datos.setearParametro("@Telefono", cli.Telefono);
                datos.setearParametro("@Direccion", cli.Direccion);
                datos.setearParametro("@Localidad", cli.Localidad);
                datos.setearParametro("@Provincia", cli.Provincia);
                datos.setearParametro("@TipoTrabajo", 1);
                datos.setearParametro("@Estado", 1);
                datos.ejecutarAccion();
                return 1;

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



        public DataTable ObtenerHistorialTrabajos()
        {
            try
            {
                datos.setearConsulta(@"SELECT ST.Id,
                                     ST.DniCliente,
                                     ST.NombreCliente,
                                     ST.ApellidoCliente,
                                     ST.DescripcionTrabajo,
                                     ST.TelefonoCliente,
                                     ST.DireccionCliente,
                                     ST.LocalidadCliente,
                                     ST.ProvinciaCliente,
                                     CASE ST.Estado 
                                        WHEN 1 THEN 'Pendiente'
                                        WHEN 2 THEN 'En Proceso'
                                        WHEN 3 THEN 'Completado'
                                        ELSE 'Desconocido'
                                     END as EstadoDescripcion,
                                     ST.TecnicoAsignado,
                                     TT.Nombre as TipoTrabajo
                              FROM SOLICITUDES_TRABAJO ST
                              LEFT JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id
                              ORDER BY ST.Id DESC");

                datos.ejecutarLectura();

                
                DataTable dt = new DataTable();
                dt.Load(datos.Lector);

                // Log para debugging
                Console.WriteLine($"Registros recuperados: {dt.Rows.Count}");

                return dt;
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
        public DataTable ObtenerHistorialCliente(string dni)
        {
            try
            {
                datos.setearConsulta("SELECT NombreCliente, DireccionCliente, DescripcionTrabajo, Estado, TecnicoAsignado " +
                                    "FROM SOLICITUDES_TRABAJO WHERE DniCliente = @Dni");
                datos.setearParametro("@Dni", dni); 
                datos.ejecutarLectura();

                DataTable dt = new DataTable();
                dt.Load(datos.Lector);
                return dt;
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

        public DataTable ObtenerReportesTrabajo(int idTrabajo)
        {
            try
            {
                datos.setearConsulta(@"SELECT RT.Id,
                                     RT.FechaReporte,
                                     RT.DescripcionReporte
                              FROM REPORTES_TRABAJO RT
                              WHERE RT.IdSolicitudTrabajo = @IdTrabajo
                              ORDER BY RT.FechaReporte DESC");

                datos.setearParametro("@IdTrabajo", idTrabajo);
                datos.ejecutarLectura();

                DataTable dt = new DataTable();
                dt.Load(datos.Lector);

                return dt;
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
        public DataTable ObtenerHistorialTrabajosPorId(int idSolicitud)
        {
            try
            {
                datos.setearConsulta(
                    @"SELECT ST.Id,
                     ST.DniCliente,
                     ST.NombreCliente,
                     ST.ApellidoCliente,
                     ST.DescripcionTrabajo,
                     ST.TelefonoCliente,
                     ST.DireccionCliente,
                     ST.LocalidadCliente,
                     ST.ProvinciaCliente,
                     CASE ST.Estado 
                        WHEN 1 THEN 'Pendiente'
                        WHEN 2 THEN 'En Proceso'
                        WHEN 3 THEN 'Completado'
                        ELSE 'Desconocido'
                     END as EstadoDescripcion,
                     ST.TecnicoAsignado,
                     TT.Nombre as TipoTrabajo,
                     (SELECT COUNT(*) FROM REPORTES_TRABAJO RT WHERE RT.IdSolicitudTrabajo = ST.Id) as CantidadReportes
              FROM SOLICITUDES_TRABAJO ST
              LEFT JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id
              WHERE ST.Id = @IdSolicitud");

                datos.setearParametro("@IdSolicitud", idSolicitud);
                datos.ejecutarLectura();

                DataTable dt = new DataTable();
                dt.Load(datos.Lector);
                return dt;
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
        public bool ExistenReportesTecnico(int idSolicitud)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM REPORTES_TRABAJO WHERE IdSolicitudTrabajo = @IdSolicitud");
                datos.setearParametro("@IdSolicitud", idSolicitud);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    return cantidad > 0;
                }

                return false;
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

    


