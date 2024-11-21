using Data_Management;
using Dominio;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;

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

                datos.setearConsulta("select Tec.CodTecnico, Tec.NivelRol, Tec.Celular, Tec.Nombre, Tec.Apellido, Tec.Localidad, Tec.Provincia, Tec.NroDocumento from TECNICOS as Tec");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tecnico aux = new Tecnico();
                    aux.CodTecnico = (string)datos.Lector["CodTecnico"];
                    aux.NivelRol = (int)datos.Lector["NivelRol"];
                    aux.Celular = (int)datos.Lector["Celular"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
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
                datos.setearConsulta("insert into TECNICOS (CodTecnico, NivelRol, Celular, Nombre, Apellido, Localidad, Provincia, NroDocumento) Values(@CodTecnico, @NivelRol, @Celular, @Nombre, @Apellido, @Localidad, @Provincia, @NroDocumento)");
                datos.setearParametro("@CodTecnico", tec.CodTecnico);
                datos.setearParametro("@NivelRol", tec.NivelRol);
                datos.setearParametro("@Celular", tec.Celular);
                datos.setearParametro("@Nombre", tec.Nombre);
                datos.setearParametro("@Apellido", tec.Apellido);
                datos.setearParametro("@Localidad", tec.Localidad);
                datos.setearParametro("@Provincia", tec.Provincia);
                datos.setearParametro("@NroDocumento", tec.NroDocumento);
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
                datos.setearConsulta("update TECNICOS set CodTecnico = @CodTecnico, NivelRol = @NivelRol, Celular = @Celular, Nombre = @Nombre, Apellido = @Apellido, Localidad = @Localidad, Provincia = @Provincia, NroDocumento = @NroDocumento where CodTecnico = @CodTecnico ");
                datos.setearParametro("@CodTecnico", tec.CodTecnico);
                datos.setearParametro("@NivelRol", tec.NivelRol);
                datos.setearParametro("@Celular", tec.Celular);
                datos.setearParametro("@Nombre", tec.Nombre);
                datos.setearParametro("@Apellido", tec.Apellido);
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
        public List<Tecnico> ListarTecnicos()
        {
            List<Tecnico> lista = new List<Tecnico>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT 
                T.Id, 
                T.CodTecnico, 
                T.NivelRol, 
                T.Celular, 
                T.Nombre, 
                T.Apellido, 
                T.Localidad, 
                T.Provincia, 
                T.NroDocumento,
                IT.ImgUrl
            FROM TECNICOS T
            LEFT JOIN IMAGENES_TECNICO IT ON T.CodTecnico = IT.CodTecnico");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tecnico tecnico = new Tecnico
                    {
                        
                        CodTecnico = datos.Lector["CodTecnico"].ToString(),
                        NivelRol = Convert.ToInt32(datos.Lector["NivelRol"]),
                        Celular = Convert.ToInt32(datos.Lector["Celular"]),
                        Nombre = datos.Lector["Nombre"].ToString(),
                        Apellido = datos.Lector["Apellido"].ToString(),
                        Localidad = datos.Lector["Localidad"].ToString(),
                        Provincia = datos.Lector["Provincia"].ToString(),
                        NroDocumento = Convert.ToInt32(datos.Lector["NroDocumento"])
                    };

                    // Verificar si la URL de imagen es válida
                    if (!string.IsNullOrEmpty(datos.Lector["ImgUrl"]?.ToString()) && Uri.IsWellFormedUriString(datos.Lector["ImgUrl"]?.ToString(), UriKind.Absolute))
                    {
                        tecnico.ImgUrl = datos.Lector["ImgUrl"].ToString();
                    }
                    else
                    {
                        tecnico.ImgUrl = "https://thumbs.dreamstime.com/z/perfil-de-usuario-vectorial-avatar-predeterminado-179376714.jpg?ct=jpeg"; // Imagen por defecto si no hay imagen válida
                    }

                    lista.Add(tecnico);
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
    }
}
