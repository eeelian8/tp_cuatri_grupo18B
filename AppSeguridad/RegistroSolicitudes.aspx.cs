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
    public partial class RegistroSolicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSolicitudesAceptadas();
            }
        }

        private void CargarSolicitudesAceptadas()
        {
            SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
            gvRegistroSolicitudes.DataSource = negocio.ListarAceptadas();
            gvRegistroSolicitudes.DataBind();
        }


        protected void gvRegistroSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button botonSelected = (Button)gvRegistroSolicitudes.SelectedRow.FindControl("btnSeleccionar");
            botonSelected.CssClass = "btn btn-primary btn-sm";

            int idSolicitud = Convert.ToInt32(gvRegistroSolicitudes.SelectedRow.Cells[0].Text);
            CargarDetallesSolicitud(idSolicitud);
        }
        private void CargarDetallesSolicitud(int id)
        {
            try
            {
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                SolicitudTrabajo solicitud = negocio.BuscarSolicitudCompleta(id);

                if (solicitud != null)
                {
                    lblTT.Text = solicitud.TipoTrabajo;
                    lblCliente.Text = solicitud.Nombre;
                    lblTecnico.Text = solicitud.TecnicoAsignado;
                    lblDireccion.Text = solicitud.Direccion + ", " + solicitud.Localidad;
                    lblDescripcion.Text = solicitud.Descripcion;
                    lblFechaInicio.Text = solicitud.FechaInicio.ToString("dd/MM/yyyy");
                    lblFechaFin.Text = solicitud.FechaFin.ToString("dd/MM/yyyy");

                }
            }
            catch (Exception ex)
            {
                Response.Write("error detalles: " + ex.Message);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gerente.aspx");
        }

        protected void ddlTareasEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
            int estado = Convert.ToInt32(ddlTareasEstado.SelectedValue);

            if (estado == 0)
            {
                gvRegistroSolicitudes.DataSource = negocio.ListarAceptadas();
            }
            else
            {
                gvRegistroSolicitudes.DataSource = negocio.ListarAceptadasXEstado(estado); //el value pero int
            }
            gvRegistroSolicitudes.DataBind();
        }
    }

}