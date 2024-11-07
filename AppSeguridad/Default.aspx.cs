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

            //crear tabla en base de datos de usuario y contrasena
            //que tenga una propiedad NivelDeRol para luego utilizar al derivar a otra ventana
            //buscar en esta tabla el usuario y contrasena ingresado en el login
           
        }
    }
}