using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;
using Negocio;

namespace AppSeguridad
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*CargarSolicitudes();*/
            }
        }
        /*
        private void CargarSolicitudes()
        {
            try
            {
                TecnicoNegocio negocio = new TecnicoNegocio();
                List<SolicitudTrabajo> lista = negocio.ListarSolicitudesPendientes();
                repTareas.DataSource = lista;
                repTareas.DataBind();

                btnAceptar.Enabled = false;
                btnDenegar.Enabled = false;
                btnAceptar.CssClass = "btn btn-secondary px-4";
                btnDenegar.CssClass = "btn btn-secondary px-4";
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar solicitudes: " + ex.Message);
            }
        }*/

        protected void repTareas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                SolicitudTrabajo solicitud = (SolicitudTrabajo)e.Item.DataItem;

                Label lblTipoTrabajo = (Label)e.Item.FindControl("lblTipoTrabajo");
                Label lblId = (Label)e.Item.FindControl("lblId");
                Label lblDescripcion = (Label)e.Item.FindControl("lblDescripcion");
                Label lblDireccion = (Label)e.Item.FindControl("lblDireccion");
                Label lblLocalidad = (Label)e.Item.FindControl("lblLocalidad");
                Label lblProvincia = (Label)e.Item.FindControl("lblProvincia");
                Label lblTelefono = (Label)e.Item.FindControl("lblTelefono");
                LinkButton lnkTrabajo = (LinkButton)e.Item.FindControl("lnkTrabajo");

                lblTipoTrabajo.Text = solicitud.TipoTrabajo;
                lblId.Text = solicitud.Id.ToString();
                lblDescripcion.Text = solicitud.Descripcion;
                lblDireccion.Text = solicitud.Direccion;
                lblLocalidad.Text = solicitud.Localidad;
                lblProvincia.Text = solicitud.Provincia;
                lblTelefono.Text = solicitud.Telefono.ToString();

                lnkTrabajo.CommandArgument = solicitud.Id.ToString();
            }
        }

        protected void tareaSeleccionada(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string idTareaSeleccionada = ((LinkButton)e.Item.FindControl("lnkTrabajo")).CommandArgument;
                Session["TareaSeleccionada"] = idTareaSeleccionada;

                btnAceptar.Enabled = true;
                btnDenegar.Enabled = true;
                btnAceptar.CssClass = "btn btn-success px-4";
                btnDenegar.CssClass = "btn btn-danger px-4";

                foreach (RepeaterItem item in repTareas.Items)
                {
                    LinkButton link = (LinkButton)item.FindControl("lnkTrabajo");
                    if (link.CommandArgument == idTareaSeleccionada)
                        link.CssClass = "list-group-item list-group-item-action active";
                    else
                        link.CssClass = "list-group-item list-group-item-action";
                }
            }
        }
    }
    /*
    protected void btnConfirmarDenegar_Click(object sender, EventArgs e)
        {
            try
            {
                string motivo = txtMotivoDenegacion.Text;
                if (string.IsNullOrEmpty(motivo))
                {
                    // msj de error
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage","alert('Debe ingresar un motivo');", true);
                    return;
                }

                // guardar motivo
                motivoRechazo = motivo;
                Session["MotivoRechazo"] = motivo;

                // limpiAr textbox y cerrar
                txtMotivoDenegacion.Text = "";

                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "closeModal",
                    "var myModal = bootstrap.Modal.getInstance(document.getElementById('modalDenegar')); myModal.hide();", true);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialTareas.aspx");
        }



    }*/
}

