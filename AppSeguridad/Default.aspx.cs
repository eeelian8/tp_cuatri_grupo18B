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
            if (ListBoxLogin.SelectedItem.Text == "Administrador")
            {
                nivelRol = 1;
            }
            else if(ListBoxLogin.SelectedItem.Text == "Gerente")
            {
                nivelRol = 2;
            }
            else if( ListBoxLogin.SelectedItem.Text == "Tecnico")
            {
                nivelRol = 3;
            }
            else if (ListBoxLogin.SelectedItem.Text == "Recepcionista")
            {
                nivelRol = 4;
            }

            UsuarioNegocio usrNegocio = new UsuarioNegocio();
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