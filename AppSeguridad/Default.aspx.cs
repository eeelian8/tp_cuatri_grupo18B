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
            Usuario usr; 
            UsuarioNegocio usrNegocio = new UsuarioNegocio();

            try
            {
                int nivelRol = 0;

                if(ListBoxLogin.SelectedItem.Text == "Administrativo")
                {
                    nivelRol = 1;
                }
                if (ListBoxLogin.SelectedItem.Text == "Gerente")
                {
                    nivelRol = 2;
                }
                if (ListBoxLogin.SelectedItem.Text == "Tecnico")
                {
                    nivelRol = 3;
                }
                if (ListBoxLogin.SelectedItem.Text == "Recepcionista")
                {
                    nivelRol = 4;
                }

                usr = new Usuario(InputUser.Text, InputPassword.Text, nivelRol);

                if (usrNegocio.Loguear(usr))
                {
                    switch (nivelRol)
                    {
                        case 1:
                            Session.Add("admin", usr);
                            Response.Redirect("Administrador.aspx", false);
                            break;
                        case 2:
                            Session.Add("gerente", usr);
                            Response.Redirect("Gerente.aspx", false);
                            break;
                        case 3:
                            Session.Add("tecnico", usr);
                            Response.Redirect("Tecnico.aspx", false);
                            break;
                        case 4:
                            Session.Add("recepcionista", usr);
                            Response.Redirect("Recepcion.aspx", false);
                            break;
                    }
                }
                else { 
                
                    
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }

           
        }
    }
}