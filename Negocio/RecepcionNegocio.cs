using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;

namespace Negocio
{
    public class RecepcionNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool ExisteDNI(string DNI)
        {

            try
            {

                datos.setearConsulta("SELECT NroCliente FROM Clientes WHERE NroCliente = @NroCliente");
                datos.setearParametro("@NroCliente", DNI);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return true;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return false;
        }
        public Recepcion GetCliente(string DNI)
        {
            Recepcion cliente =null;
            try
            {
                datos.setearConsulta("SELECT * FROM Clientes WHERE NroCliente = @NroCliente");
                datos.setearParametro("@NroCliente", DNI);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente = new Recepcion();
                   

                        cliente.Documento = DNI;
                        cliente.Nombre = (string)datos.Lector["Nombre"];
                        cliente.Telefono = (int)datos.Lector["Celular"];
                       // cliente.Email = (string)datos.Lector["Email"];
                       cliente.Direccion = (string)datos.Lector["Direccion"];
                       cliente.Localidad = (string)datos.Lector["Localidad"];
                        cliente.Provincia = (string)datos.Lector["Provincia"];

                   

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
        public List<Recepcion> Listar()
        {
            List<Recepcion> lista = new List<Recepcion>();


            try
            {

                datos.setearConsulta("select Cli.Documento , Cli.Nombre,Cli.Telefono  Cli.Direccion, Cli.Localidad, Cli.Provincia from CLIENTES as Cli");
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Recepcion aux = new Recepcion();
                    aux.Documento = (string)datos.Lector["dni"];
                    aux.Telefono = (int)datos.Lector["Telefono"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Localidad = (string)datos.Lector["Localidad"];


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
        public void Agregar(Recepcion cli)
        {


            try
            {
                datos.setearConsulta("insert into CLIENTES ( NroCliente, Nombre,Celular,Direccion, Localidad, Provincia) Values(@Dni, @Telefono, @Nombre,  @Direccion, @Localidad, @Provincia)");
                datos.setearParametro("@Dni", cli.Documento);
                datos.setearParametro("@Nombre", cli.Nombre);
                datos.setearParametro("@Telefono", cli.Telefono);
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

        public void Modificar(Recepcion cli)
        {

            try
            {
                datos.setearConsulta("update CLIENTES set Documento= @Dni , Nombre = @Nombre, Telefono = @Telefono, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia where Documento = @Dni ");
                datos.setearParametro("@Dni", cli.Documento);
                datos.setearParametro("@Nombre", cli.Nombre);
                datos.setearParametro("@Telefono", cli.Telefono);
                datos.setearParametro("@Direccion", cli.Direccion);
                datos.setearParametro("@Localidad", cli.Localidad);
                datos.setearParametro("@Provincia", cli.Provincia);
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Recepcion Buscar(int dni)
        {
            RecepcionNegocio clienteNeg = new RecepcionNegocio();
            List<Recepcion> ListaClientes = new List<Recepcion>();
            ListaClientes = clienteNeg.Listar();

            try
            {
                foreach (Recepcion cli in ListaClientes)
                {
                    if (cli.Documento == dni.ToString())
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
