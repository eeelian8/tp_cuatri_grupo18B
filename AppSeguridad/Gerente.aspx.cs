using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;
using Negocio;

namespace AppSeguridad
{
    public partial class Gerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SolicitudTrabajoNegocio stNegocio = new SolicitudTrabajoNegocio();
            gv_solicitudes.DataSource = stNegocio.listarConSP();
            gv_solicitudes.DataBind();
        }
    }
}