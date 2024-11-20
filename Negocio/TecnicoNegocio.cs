using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;

namespace Negocio
{
    public class TecnicoNegocio
    {
        public List<Tecnico> Listar()
        {
            List<Tecnico> lista = new List<Tecnico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select Tec.CodTecnico, Tec.NivelRol, Tec.Celular, Tec.Nombre, Tec.Apellido, Tec.Direccion, Tec.Localidad, Tec.Provincia from TECNICOS as Tec");
                datos.ejecutarLectura(); 

                while (datos.Lector.Read())
                {
                    Tecnico aux = new Tecnico();
                    aux.CodTecnico = (string)datos.Lector["CodTecnico"];
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
        public void ValidacionAgregar(Tecnico tec)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select count(*) from TECNICOS where CodTecnico = @CodTecnico");
                datos.setearParametro("@CodTecnico", tec.CodTecnico);
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
        public void Agregar(Tecnico tec)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into TECNICOS (CodTecnico, NivelRol, Celular, Nombre, Apellido, Direccion, Localidad, Provincia) Values(@CodTecnico, @NivelRol, @Celular, @Nombre, @Apellido, @Direccion, @Localidad, @Provincia)");
                datos.setearParametro("@CodTecnico", tec.CodTecnico);
                datos.setearParametro("@NivelRol", tec.NivelRol);
                datos.setearParametro("@Celular", tec.Celular);
                datos.setearParametro("@Nombre", tec.Nombre);
                datos.setearParametro("@Apellido", tec.Apellido);
                datos.setearParametro("@Direccion", tec.Direccion);
                datos.setearParametro("@Localidad", tec.Localidad);
                datos.setearParametro("@Provincia", tec.Provincia);
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

        public void Modificar(Tecnico tec)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update TECNICOS set CodTecnico = @CodTecnico, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Localidad = @Localidad, Provincia = @Provincia where CodTecnico = @CodTecnico ");
                datos.setearParametro("@CodTecnico", tec.CodTecnico);
                datos.setearParametro("@NivelRol", tec.NivelRol);
                datos.setearParametro("@Celular", tec.Celular);
                datos.setearParametro("@Nombre", tec.Nombre);
                datos.setearParametro("@Apellido", tec.Apellido);
                datos.setearParametro("@Direccion", tec.Direccion);
                datos.setearParametro("@Localidad", tec.Localidad);
                datos.setearParametro("@Provincia", tec.Provincia);
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
                datos.setearConsulta("delete from TECNICOS where CodTecnico = @CodTecnico");
                datos.setearParametro("@CodTecnico", cod);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Tecnico Buscar(string cod)
        {
            TecnicoNegocio tecnicoNeg = new TecnicoNegocio();
            List<Tecnico> ListaTecnicos = new List<Tecnico>();
            ListaTecnicos = tecnicoNeg.Listar();

            try
            {
                foreach (Tecnico tec in ListaTecnicos)
                {
                    if (tec.CodTecnico == cod)
                    {
                        return tec;
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
