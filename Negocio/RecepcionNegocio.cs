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
                datos.setearConsulta("SELECT Nombre FROM TIPOS_TRABAJO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new TipoTrabajo
                    {
                        Nombre = (string)datos.Lector["Nombre"]
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
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta("SELECT DniCliente as Dni, tt.Nombre as Trabajo, NombreCliente as Nombre, ApellidoCliente as Apellido, DescripcionTrabajo as Descripcion, TelefonoCliente as Telefono, DireccionCliente as Direccion, LocalidadCliente as Localidad, ProvinciaCliente as Provincia,  Estado FROM SOLICITUDES_TRABAJO st inner join TIPOS_TRABAJO tt on st.IdTipoTrabajo = tt.Id");

                datos.ejecutarLectura();
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
        public DataTable ObtenerHistorialCliente(int dni)
        {
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta("SELECT NombreCliente as Nombre, TelefonoCliente as Telefono, DireccionCliente as Direccion, tt.Nombre as Trabajo, DescripcionTrabajo as Descripcion, t.Nombre + ' ' + t.Apellido as Tecnico, Estado FROM SOLICITUDES_TRABAJO st inner join TECNICOS t on st.TecnicoAsignado = t.CodTecnico inner join TIPOS_TRABAJO tt on st.IdTipoTrabajo = tt.Id WHERE DniCliente = @Dni");
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();
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
    }
}
    


