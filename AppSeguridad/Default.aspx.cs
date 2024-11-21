using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSeguridad
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            string usuario = InputUser.Text;
            string password = InputPassword.Text;
            int nivelRol = 0;
            Usuario usrAux;

            UsuarioNegocio usrNegocio = new UsuarioNegocio();
            List<Usuario> listaUsuarios = usrNegocio.Listar();
            usrAux = listaUsuarios.Find(x => x.usuario == usuario);

            if (usrAux != null)
            {
                nivelRol = usrAux.nivelRol;   
            }

            if (usrNegocio.Loguear(usuario, password, nivelRol))
            {
                switch (nivelRol)
                {
                    case 1:
                        Response.Redirect("Administrador.aspx", false);
                        break;
                    case 2:
                        Response.Redirect("Gerente.aspx", false);
                        break;
                    case 3:
                        Response.Redirect("Tecnico.aspx?usr="+usuario, false);
                        break;
                    case 4:
                        Response.Redirect("Recepcion.aspx", false);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                LabelLogin.Text = "Contraseña o usuario equivocado... intente nuevamente o comuniquese con su administrador.";
            }

        }
    }
}