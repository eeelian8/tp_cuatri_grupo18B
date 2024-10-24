using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;

namespace Negocio
{
    public class GerenteNegocio
    {
        public List<Gerente> Listar()
        {
            List<Gerente> lista = new List<Gerente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ger.CodGerente, ger.NivelRol, ger.Celular, ger.Nombre, ger.Apellido, ger.Direccion, ger.Localidad, ger.Provincia from GERENTE as ger");
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    Gerente aux = new Gerente();
                    aux.CodGerente = (string)datos.Lector["CodGerente"];
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
        public void ValidacionAgregar(Gerente ger)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select count(*) from GERENTE where CodGerente = @CodGerente");
                datos.setearParametro("@CodGerente", ger.CodGerente);
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
        public void Agregar(Gerente ger)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into GERENTE (CodGerente, NivelRol, Celular, Nombre, Apellido, Direccion, Localidad, Provincia) Values(@CodGerente, @NivelRol, @Celular, @Nombre, @Apellido, @Direccion, @Localidad, @Provincia)");
                datos.setearParametro("@CodGerente", ger.CodGerente);
                datos.setearParametro("@NivelRol", ger.NivelRol);
                datos.setearParametro("@Celular", ger.Celular);
                datos.setearParametro("@Nombre", ger.Nombre);
                datos.setearParametro("@Apellido", ger.Apellido);
                datos.setearParametro("@Direccion", ger.Direccion);
                datos.setearParametro("@Localidad", ger.Localidad);
                datos.setearParametro("@Provincia", ger.Provincia);
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

        public void Modificar(Gerente ger)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update GERENTE set CodGerente = @CodGerente, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia where CodGerente = @CodGerente ");
                datos.setearParametro("@CodGerente", ger.CodGerente);
                datos.setearParametro("@NivelRol", ger.NivelRol);
                datos.setearParametro("@Celular", ger.Celular);
                datos.setearParametro("@Nombre", ger.Nombre);
                datos.setearParametro("@Apellido", ger.Apellido);
                datos.setearParametro("@Direccion", ger.Direccion);
                datos.setearParametro("@Localidad", ger.Localidad);
                datos.setearParametro("@Provincia", ger.Provincia);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(string cod)
        {

            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from GERENTE where CodGerente = @CodGerente");
                datos.setearParametro("@CodGerente", cod);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Gerente Buscar(string cod)
        {
            GerenteNegocio gerenteNeg = new GerenteNegocio();
            List<Gerente> ListaGerentes = new List<Gerente>();
            ListaGerentes = gerenteNeg.Listar();

            try
            {
                foreach (Gerente aux in ListaGerentes)
                {
                    if (aux.CodGerente == cod)
                    {
                        return aux;
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
