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
                CargarTiposTrabajo();
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
        //el dropdownlist
        private void CargarTiposTrabajo()
        {
            try
            {
                ddlTrabajoType.Items.Clear();//limpia lista del ddl

                TipoTrabajoNegocio negocio = new TipoTrabajoNegocio();
                ddlTrabajoType.DataSource = negocio.Listar();
                ddlTrabajoType.DataTextField = "Nombre"; //propiedad de TT qe mostrara el dropdown
                ddlTrabajoType.DataValueField = "Id"; // propiedad de TT como valor interno
                ddlTrabajoType.DataBind();

                ddlTrabajoType.Items.Insert(0, new ListItem("todos los trabajos", "0")); //insert Opcion 0 = todos
                ddlTrabajoType.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                Response.Write("error en listado x tipo: " + ex.Message);
            }
        }

        protected void gv_solicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button botonSelected = (Button)gv_solicitudes.SelectedRow.FindControl("btnSelect");
            botonSelected.CssClass = "btn btn-primary btn-sm";//cambia su cssClass a primary

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
        protected void btnRegistroSolicitudes_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroSolicitudes.aspx");
        }

        protected void ddlTrabajoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = ddlTrabajoType.SelectedItem.Text;
            SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();

            if (ddlTrabajoType.SelectedValue == "0") // Si seleccionó "Todos los trabajos"
            {
                gv_solicitudes.DataSource = negocio.ListarPendientes();
            }
            else
            {
                gv_solicitudes.DataSource = negocio.ListarPendientesXTipo(tipoSeleccionado);
            }

            gv_solicitudes.DataBind();
        }
    }

}




