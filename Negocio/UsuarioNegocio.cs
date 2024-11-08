﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Data_Management;
using Dominio;  

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(string user, string pass, int nr)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select U.Id, U.Usuario, U.Password, U.NivelRol from USUARIOS as U where U.Usuario = @user AND U.Password = @pass AND U.NivelRol = @nr");
                datos.setearParametro("@user", user);
                datos.setearParametro("@pass", pass);
                datos.setearParametro("@nr", nr);
                datos.ejecutarLectura();

                int count = 0;
                if (datos.Lector.Read())
                {
                    count = (int)datos.Lector[0];
                }

                if (count > 0)
                {
                    return true;
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

            return false;
        }

    }
}
