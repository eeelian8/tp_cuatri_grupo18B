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
            CargarSolicitudes();
            if (!IsPostBack)
            {
                btnAceptar.Enabled = false;
                btnDenegar.Enabled = false;
                btnAceptar.CssClass = "btn btn-secondary px-4";
                btnDenegar.CssClass = "btn btn-secondary px-4";
            }
        }

        protected void CargarDatos(object sender, RepeaterItemEventArgs e)
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

        private void CargarSolicitudes()
        {
            try
            {
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                List<SolicitudTrabajo> lista = negocio.ListarPendientes();  // lista las que tienen Estado = 1
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
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string idTarea = Session["TareaSeleccionada"].ToString();
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                negocio.Aceptar(int.Parse(idTarea));

                //volver estado original (ya no hace falta + creo esto de recargar los botones)
                CargarSolicitudes();
                btnAceptar.Enabled = false;
                btnDenegar.Enabled = false;
                btnAceptar.CssClass = "btn btn-secondary px-4";
                btnDenegar.CssClass = "btn btn-secondary px-4";
            }
            catch (Exception ex)
            {
                Response.Write("Error al aceptar la solicitud: " + ex.Message);
            }
        }

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

                lnkTrabajo.CommandArgument = solicitud.Id.ToString(); //(mantiene seleccion)
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

       


        protected void btnConfirmarDenegar_Click(object sender, EventArgs e)
    {
        try
        {
            string motivo = txtMotivoDenegacion.Text;
            if (string.IsNullOrEmpty(motivo))//no motivos vacios
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Debe ingresar un motivo');", true);
                return;
            }

            Session["MotivoRechazo"] = motivo;//session que desp llegara a Gerente.aspx
            txtMotivoDenegacion.Text = ""; //limpiar textbox

                string idTarea = Session["TareaSeleccionada"].ToString();
                SolicitudTrabajoNegocio solicitud = new SolicitudTrabajoNegocio();
                solicitud.Rechazar(int.Parse(idTarea)); //estado solicitud a 3(rechazado)

                ScriptManager.RegisterStartupScript(this, this.GetType(), "closeModal",
                "var myModal = bootstrap.Modal.getInstance(document.getElementById('modalDenegar')); myModal.hide();", true);

                CargarSolicitudes();//recargar pagina
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



    }
}

