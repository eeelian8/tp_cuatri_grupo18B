using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace Negocio
{
    public class SolicitudTrabajoNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<SolicitudTrabajo> ListarPendientes()
        {
            List<SolicitudTrabajo> lista = new List<SolicitudTrabajo>();

            try
            {
                datos.setearConsulta("SELECT ST.Id, ST.DniCliente as Dni, TT.Nombre as TipoTrabajo, ST.NombreCliente as Nombre, ST.TelefonoCliente as Telefono, ST.DescripcionTrabajo as Descripcion, TT.DuracionCantDias as DuracionDias, ST.ProvinciaCliente as Provincia, ST.LocalidadCliente as Localidad, ST.ApellidoCliente as Apellido, ST.DireccionCliente as Direccion FROM SOLICITUDES_TRABAJO ST INNER JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id WHERE ST.Estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    SolicitudTrabajo aux = new SolicitudTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.TipoTrabajo = (string)datos.Lector["TipoTrabajo"] + " (" +datos.Lector["DuracionDias"].ToString() + " días)";
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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
        public List<SolicitudTrabajo> ListarPendientesXTipo(string tipoTrabajo)
        {
            List<SolicitudTrabajo> lista = new List<SolicitudTrabajo>();

            try
            {
                datos.setearConsulta("SELECT ST.Id, ST.DniCliente as Dni, TT.Nombre as TipoTrabajo, ST.NombreCliente as Nombre, ST.TelefonoCliente as Telefono, ST.DescripcionTrabajo as Descripcion, TT.DuracionCantDias as DuracionDias, ST.ProvinciaCliente as Provincia, ST.LocalidadCliente as Localidad, ST.ApellidoCliente as Apellido, ST.DireccionCliente as Direccion FROM SOLICITUDES_TRABAJO ST INNER JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id WHERE ST.Estado = 1 AND TT.Nombre = @TipoTrabajo");
                datos.setearParametro("@TipoTrabajo", tipoTrabajo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    SolicitudTrabajo aux = new SolicitudTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.TipoTrabajo = (string)datos.Lector["TipoTrabajo"] + " (" + datos.Lector["DuracionDias"].ToString() + " días)";
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void Agregar(SolicitudTrabajo solicitud) ///new consulta
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO SOLICITUDES_TRABAJO (Dni, TipoTrabajo, Nombre, Apellido, Descripcion, Telefono, Direccion, Localidad, Provincia, Estado) VALUES (@Dni, @TipoTrabajo, @Nombre, @Apellido, @Descripcion, @Telefono, @Direccion, @Localidad, @Provincia, @Estado)");

                datos.setearParametro("@Dni", solicitud.Dni);
                datos.setearParametro("@TipoTrabajo", solicitud.TipoTrabajo);
                datos.setearParametro("@Nombre", solicitud.Nombre);
                datos.setearParametro("@Apellido", solicitud.Apellido);
                datos.setearParametro("@Descripcion", solicitud.Descripcion);
                datos.setearParametro("@Telefono", solicitud.Telefono);
                datos.setearParametro("@Direccion", solicitud.Direccion);
                datos.setearParametro("@Localidad", solicitud.Localidad);
                datos.setearParametro("@Provincia", solicitud.Provincia);
                datos.setearParametro("@Estado", 0); // 0 = pendiente para gerente

                datos.ejecutarAccion();
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

        public void Aceptar(int id)
        {
            try
            {
                /// aceptar solicitud = 2
                datos.setearConsulta("UPDATE SOLICITUDES_TRABAJO SET Estado = 2 WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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


        public void Rechazar(int id)
        {
            try
            {   /// rechazar (x tecnicos) estado = 3
                datos.setearConsulta("UPDATE SOLICITUDES_TRABAJO SET Estado = 3 WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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

        public SolicitudTrabajo Buscar(int id)
        {
            SolicitudTrabajo solicitud = null;
            try
            {
                datos.setearConsulta("SELECT soli.Id, soli.DniCliente as Dni, TT.Nombre as TipoTrabajo, soli.NombreCliente as Nombre, soli.TelefonoCliente as Telefono, soli.ProvinciaCliente as Provincia, soli.LocalidadCliente as Localidad, soli.ApellidoCliente as Apellido, soli.DireccionCliente as Direccion, soli.DescripcionTrabajo as Descripcion, soli.Estado  FROM SOLICITUDES_TRABAJO as soli INNER JOIN TIPOS_TRABAJO as TT ON soli.IdTipoTrabajo = TT.Id WHERE soli.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    solicitud = new SolicitudTrabajo();
                    solicitud.Id = (int)datos.Lector["Id"];
                    solicitud.Dni = (int)datos.Lector["Dni"];
                    solicitud.TipoTrabajo = (string)datos.Lector["TipoTrabajo"];
                    solicitud.Nombre = (string)datos.Lector["Nombre"];
                    solicitud.Apellido = (string)datos.Lector["Apellido"];
                    solicitud.Descripcion = (string)datos.Lector["Descripcion"];
                    solicitud.Telefono = (int)datos.Lector["Telefono"];
                    solicitud.Direccion = (string)datos.Lector["Direccion"];
                    solicitud.Localidad = (string)datos.Lector["Localidad"];
                    solicitud.Provincia = (string)datos.Lector["Provincia"];
                    solicitud.Estado = (int)datos.Lector["Estado"];
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
            return solicitud;
        }
        public List<SolicitudTrabajo> ListarAceptadas()
        {
            List<SolicitudTrabajo> lista = new List<SolicitudTrabajo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select st.Id, DniCliente, tt.Nombre as TipoTrabajo, tt.DuracionCantDias, NombreCliente, ApellidoCliente, DescripcionTrabajo, tec.Nombre as NombreTecnico, tec.Apellido as ApellidoTecnico, TecnicoAsignado, DireccionCliente, LocalidadCliente, TelefonoCliente, ProvinciaCliente, Estado from SOLICITUDES_TRABAJO as st inner join TIPOS_TRABAJO as tt on st.IdTipoTrabajo = tt.Id inner join TECNICOS as tec on st.TecnicoAsignado = tec.CodTecnico inner join FECHAS_TRABAJO as ft on st.Id = ft.IdSolicitudTrabajo where Estado = 2");//2 aceptadas
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    SolicitudTrabajo aux = new SolicitudTrabajo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (int)datos.Lector["DniCliente"];
                    aux.TipoTrabajo = (string)datos.Lector["TipoTrabajo"] + " (" + datos.Lector["DuracionCantDias"].ToString() + " días)";
                    aux.Nombre = (string)datos.Lector["NombreCliente"];
                    aux.Apellido = (string)datos.Lector["ApellidoCliente"];
                    aux.Descripcion = (string)datos.Lector["DescripcionTrabajo"];
                    aux.Telefono = (int)datos.Lector["TelefonoCliente"];
                    aux.Direccion = (string)datos.Lector["DireccionCliente"];
                    aux.Localidad = (string)datos.Lector["LocalidadCliente"];
                    aux.Provincia = (string)datos.Lector["ProvinciaCliente"];
                    aux.TecnicoAsignado = (string)datos.Lector["NombreTecnico"] + " " + datos.Lector["ApellidoTecnico"];
                    aux.Estado = (int)datos.Lector["Estado"];

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

        public SolicitudTrabajo BuscarSolicitudCompleta(int id)
        {
            SolicitudTrabajo solicitud = null;
            try
            {
                datos.setearConsulta("SELECT soli.Id, soli.DniCliente as Dni, TT.Nombre as TipoTrabajo, soli.NombreCliente as Nombre, soli.TelefonoCliente as Telefono, soli.ProvinciaCliente as Provincia, soli.LocalidadCliente as Localidad, soli.ApellidoCliente as Apellido, soli.DireccionCliente as Direccion, soli.DescripcionTrabajo as Descripcion, soli.Estado, tec.Nombre as NombreTecnico, tec.Apellido as ApellidoTecnico, FT.FechaInicio, FT.FechaFin FROM SOLICITUDES_TRABAJO as soli INNER JOIN TIPOS_TRABAJO as TT ON soli.IdTipoTrabajo = TT.Id INNER JOIN TECNICOS as tec ON soli.TecnicoAsignado = tec.CodTecnico INNER JOIN FECHAS_TRABAJO as FT ON soli.Id = FT.IdSolicitudTrabajo WHERE soli.Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    solicitud = new SolicitudTrabajo();
                    solicitud.Id = (int)datos.Lector["Id"];
                    solicitud.TipoTrabajo = (string)datos.Lector["TipoTrabajo"];
                    solicitud.Nombre = (string)datos.Lector["Nombre"];
                    solicitud.Apellido = (string)datos.Lector["Apellido"];
                    solicitud.Descripcion = (string)datos.Lector["Descripcion"];
                    solicitud.Direccion = (string)datos.Lector["Direccion"];
                    solicitud.Localidad = (string)datos.Lector["Localidad"];
                    solicitud.TecnicoAsignado = (string)datos.Lector["NombreTecnico"] + " " + datos.Lector["ApellidoTecnico"];
                    if (datos.Lector["FechaInicio"] != DBNull.Value)
                        solicitud.FechaInicio = (DateTime)datos.Lector["FechaInicio"];
                    if (datos.Lector["FechaFin"] != DBNull.Value)
                        solicitud.FechaFin = (DateTime)datos.Lector["FechaFin"];
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
            return solicitud;
        }

        public int ObtenerDuracionTrabajo(int idSolicitud)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"SELECT TT.DuracionCantDias 
                              FROM SOLICITUDES_TRABAJO ST 
                              INNER JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id 
                              WHERE ST.Id = @IdSolicitud");
                datos.setearParametro("@IdSolicitud", idSolicitud);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["DuracionCantDias"];
                }
                throw new Exception("trabajo no encontrado");
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
        public void AsignarTecnico(int idSolicitud, string codTecnico, DateTime fechaInicio, DateTime fechaFin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE SOLICITUDES_TRABAJO SET TecnicoAsignado = @CodTecnico, Estado = 2 WHERE Id = @IdSolicitud");
                datos.setearParametro("@CodTecnico", codTecnico);
                datos.setearParametro("@IdSolicitud", idSolicitud);
                datos.ejecutarAccion();

                
                datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO FECHAS_TRABAJO (IdSolicitudTrabajo, FechaAsignacionTecnico, FechaInicio, FechaFin) VALUES (@IdSolicitud, GETDATE(), @FechaInicio, @FechaFin)");
                datos.setearParametro("@IdSolicitud", idSolicitud);
                datos.setearParametro("@FechaInicio", fechaInicio);
                datos.setearParametro("@FechaFin", fechaFin);
                datos.ejecutarAccion();
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