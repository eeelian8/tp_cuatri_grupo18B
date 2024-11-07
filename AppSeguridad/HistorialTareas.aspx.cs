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
    }
}