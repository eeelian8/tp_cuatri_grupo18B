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
                datos.setearConsulta("SELECT ST.Id, ST.DniCliente as Dni, TT.Nombre as TipoTrabajo, ST.NombreCliente as Nombre, ST.TelefonoCliente as Telefono, ST.ProvinciaCliente as Provincia, ST.LocalidadCliente as Localidad, ST.ApellidoCliente as Apellido, ST.DireccionCliente as Direccion FROM SOLICITUDES_TRABAJO ST INNER JOIN TIPOS_TRABAJO TT ON ST.IdTipoTrabajo = TT.Id WHERE ST.Estado = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    SolicitudTrabajo aux = new SolicitudTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.TipoTrabajo = (string)datos.Lector["TipoTrabajo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Direccion = (string)datos.Lector["Direccion"];

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
                datos.setearConsulta("SELECT * FROM SOLICITUDES_TRABAJO WHERE Id = @Id");
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
                datos.setearConsulta("SELECT * FROM SOLICITUDES_TRABAJO WHERE Estado = 2");  // 2 = Aceptadas
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    SolicitudTrabajo aux = new SolicitudTrabajo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (int)datos.Lector["Dni"];
                    aux.TipoTrabajo = (string)datos.Lector["TipoTrabajo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
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