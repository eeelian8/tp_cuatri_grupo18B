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
    public partial class HistorialTareas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTareasAceptadas(); 
            }
        }

        private void CargarTareasAceptadas()
        {
            try
            {
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                List<SolicitudTrabajo> lista = negocio.ListarAceptadas();
                repTareasAceptadas.DataSource = lista;
                repTareasAceptadas.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar tareas aceptadas: " + ex.Message);
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

            
            lblTipoTrabajo.Text = solicitud.TipoTrabajo;
            lblId.Text = solicitud.Id.ToString();
            lblDescripcion.Text = solicitud.Descripcion;
            lblDireccion.Text = solicitud.Direccion;
            lblLocalidad.Text = solicitud.Localidad;
            lblProvincia.Text = solicitud.Provincia;
            lblTelefono.Text = solicitud.Telefono.ToString();
        }
    }
}