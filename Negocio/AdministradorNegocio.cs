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

                datos.setearConsulta("select Adm.CodAdministrador, Adm.NivelRol, Adm.Celular, Adm.Nombre, Adm.Apellido, Adm.Direccion, Adm.Localidad, Adm.Provincia from ADMINISTRADOR as Adm");
                datos.ejecutarLectura();;

                while (datos.Lector.Read())
                {
                    Administrador aux = new Administrador();
                    aux.CodAdministrador = (string)datos.Lector["CodAdministrador"];
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
        public void ValidacionAgregar(Administrador adm)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select count(*) from ADMNINISTRADOR where CodAdministrador = @CodAdministrador");
                datos.setearParametro("@CodAdministrador", adm.CodAdministrador);
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
                datos.setearConsulta("insert into ADMINISTRADOR (CodAdministrador, NivelRol, Celular, Nombre, Apellido, Direccion, Localidad, Provincia) Values(@CodAdministrador, @NivelRol, @Celular, @Nombre, @Apellido, @Direccion, @Localidad, @Provincia)");
                datos.setearParametro("@CodAdministrador", adm.CodAdministrador);
                datos.setearParametro("@NivelRol", adm.NivelRol);
                datos.setearParametro("@Celular", adm.Celular);
                datos.setearParametro("@Nombre", adm.Nombre);
                datos.setearParametro("@Apellido", adm.Apellido);
                datos.setearParametro("@Direccion", adm.Direccion);
                datos.setearParametro("@Localidad", adm.Localidad);
                datos.setearParametro("@Provincia", adm.Provincia);
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
                datos.setearConsulta("update ADMINISTRADOR set CodAdministrador = @CodAdministrador, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia where CodAdministrador = @CodAdministrador ");
                datos.setearParametro("@CodAdministrador", adm.CodAdministrador);
                datos.setearParametro("@NivelRol", adm.NivelRol);
                datos.setearParametro("@Celular", adm.Celular);
                datos.setearParametro("@Nombre", adm.Nombre);
                datos.setearParametro("@Apellido", adm.Apellido);
                datos.setearParametro("@Direccion", adm.Direccion);
                datos.setearParametro("@Localidad", adm.Localidad);
                datos.setearParametro("@Provincia", adm.Provincia);
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

