using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select Cli.NroCliente, Cli.NivelRol, Cli.Celular, Cli.Nombre, Cli.Apellido, Cli.Direccion, Cli.Localidad, Cli.Provincia from CLIENTES as Cli");
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.NroCliente = (int)datos.Lector["NroCliente"];
                    aux.NivelRol = (int)datos.Lector["NivelRol"];
                    aux.Celular = (int)datos.Lector["Celular"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];

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
        public void ValidacionAgregar(Cliente cli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select count(*) from CLIENTES where NroCliente = @NroCliente");
                datos.setearParametro("@NroCliente", cli.NroCliente);
                datos.ejecutarLectura();

                int count = 0;
                if (datos.Lector.Read())
                {
                    count = (int)datos.Lector[0];
                }

                if (count > 0)
                {

                    throw new Exception("Ya existe un usuario con este código.");
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
        }
        public void Agregar(Cliente cli)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into CLIENTES (NroCliente, NivelRol, Celular, Nombre, Apellido, Direccion, Localidad, Provincia) Values(@NroCliente, @NivelRol, @Celular, @Nombre, @Apellido, @Direccion, @Localidad, @Provincia)");
                datos.setearParametro("@NroCliente", cli.NroCliente);
                datos.setearParametro("@NivelRol", cli.NivelRol);
                datos.setearParametro("@Celular", cli.Celular);
                datos.setearParametro("@Nombre", cli.Nombre);
                datos.setearParametro("@Apellido", cli.Apellido);
                datos.setearParametro("@Direccion", cli.Direccion);
                datos.setearParametro("@Localidad", cli.Localidad);
                datos.setearParametro("@Provincia", cli.Provincia);
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

        public void Modificar(Cliente cli)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update CLIENTES set NroCliente = @NroCliente, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia where NroCliente = @NroCliente ");
                datos.setearParametro("@NroCliente", cli.NroCliente);
                datos.setearParametro("@NivelRol", cli.NivelRol);
                datos.setearParametro("@Celular", cli.Celular);
                datos.setearParametro("@Nombre", cli.Nombre);
                datos.setearParametro("@Apellido", cli.Apellido);
                datos.setearParametro("@Direccion", cli.Direccion);
                datos.setearParametro("@Localidad", cli.Localidad);
                datos.setearParametro("@Provincia", cli.Provincia);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int nro)
        {

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from CLIENTES where NroCliente = @NroCliente");
                datos.setearParametro("@NroCliente", nro);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cliente Buscar(int nro)
        {
            ClienteNegocio clienteNeg = new ClienteNegocio();
            List<Cliente> ListaClientes = new List<Cliente>();
            ListaClientes = clienteNeg.Listar();

            try
            {
                foreach (Cliente cli in ListaClientes)
                {
                    if (cli.NroCliente == nro)
                    {
                        return cli;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
