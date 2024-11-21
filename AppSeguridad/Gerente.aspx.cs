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
            if (!IsPostBack)
            {
                CargarSolicitudesPendientes();
            }

        }

        private void CargarSolicitudesPendientes()
        {
            try
            {
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                gv_solicitudes.DataSource = negocio.ListarPendientes();
                gv_solicitudes.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void gv_solicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idSolicitud = Convert.ToInt32(gv_solicitudes.SelectedRow.Cells[0].Text); //ID solicitud TIENE que estar en pos[0]
            Session["IdSolicitudSeleccionada"] = idSolicitud;
            btnAsignarTrabajo.Enabled = true;
        }

        protected void btnAsignarTrabajo_Click(object sender, EventArgs e)
        {
            if (Session["IdSolicitudSeleccionada"] != null)
            {
                Response.Redirect("AsignarTecnico.aspx");
            }
        }

        protected void btnTarjetasTecnicos_Click(object sender, EventArgs e)
        {
            Response.Redirect("TarjetaTecnicos.aspx");
        }
    }

}




