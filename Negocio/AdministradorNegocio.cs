using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Data_Management;
using Dominio;

namespace Negocio
{
    public class AdministradorNegocio
    {
        public List<Administrador> Listar()
        {
            List<Administrador> lista = new List<Administrador>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select adm.CodAdminitrador, adm.NivelRol, adm.Celular, adm.Nombre, adm.Apellido, adm.NroDocumento from ADMINISTRADORES as adm");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Administrador aux = new Administrador();
                    aux.CodAdministrador = (string)datos.Lector["CodAdminitrador"];
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
        public void ValidacionAgregar(Administrador adm)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select count(*) from ADMNINISTRADORES where CodAdminitrador = @CodAdminitrador");
                datos.setearParametro("@CodAdminitrador", adm.CodAdministrador);
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
        public void Agregar(Administrador adm)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ADMINISTRADORES (CodAdminitrador, NivelRol, Celular, Nombre, Apellido, NroDocumento) Values(@CodAdminitrador, @NivelRol, @Celular, @Nombre, @Apellido, @NroDocumento)");
                datos.setearParametro("@CodAdminitrador", adm.CodAdministrador);
                datos.setearParametro("@NivelRol", adm.NivelRol);
                datos.setearParametro("@Celular", adm.Celular);
                datos.setearParametro("@Nombre", adm.Nombre);
                datos.setearParametro("@Apellido", adm.Apellido);
                datos.setearParametro("@NroDocumento", adm.NroDocumento);
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

        public void Modificar(Administrador adm)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ADMINISTRADORES set CodAdminitrador = @CodAdminitrador, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, NroDocumento = @NroDocumento where CodAdminitrador = @CodAdminitrador ");
                datos.setearParametro("@CodAdminitrador", adm.CodAdministrador);
                datos.setearParametro("@NivelRol", adm.NivelRol);
                datos.setearParametro("@Celular", adm.Celular);
                datos.setearParametro("@Nombre", adm.Nombre);
                datos.setearParametro("@Apellido", adm.Apellido);
                datos.setearParametro("@NroDocumento", adm.NroDocumento);
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
                datos.setearConsulta("delete from ADMINISTRADOR where CodAdministrador = @CodAdministrador");
                datos.setearParametro("@CodAdministrador", cod);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Administrador Buscar(string cod)
        {
            AdministradorNegocio adminNeg = new AdministradorNegocio();
            List<Administrador> ListaAdministradores = new List<Administrador>();
            ListaAdministradores = adminNeg.Listar();

            try
            {
                foreach (Administrador adm in ListaAdministradores)
                {
                    if (adm.CodAdministrador == cod)
                    {
                        return adm;
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

