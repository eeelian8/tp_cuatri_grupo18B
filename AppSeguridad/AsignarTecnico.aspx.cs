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
    public partial class AsignarTecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calFecha.SelectedDate = DateTime.Today; //solo fecha desde hoy
                
                CargarTecnicosDisponibles();
            }
        }

        protected void calFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            // Deshabilitar fechas pasadas
            if (e.Day.Date < DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
        }

        protected void calFecha_SelectionChanged(object sender, EventArgs e)
        {
            CargarTecnicosDisponibles(); 
        }

        private void CargarTecnicosDisponibles()
        {
            try
            {
                TecnicoNegocio negocio = new TecnicoNegocio();
                repTecnicos.DataSource = negocio.ListarTecnicosDisponibles(calFecha.SelectedDate);
                repTecnicos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                string codTecnicoSeleccionado = null;
                foreach (RepeaterItem item in repTecnicos.Items)
                {
                    RadioButton rb = (RadioButton)item.FindControl("rbTecnico");
                    if (rb != null && rb.Checked)
                    {
                        codTecnicoSeleccionado = rb.Attributes["value"];
                        break;
                    }
                }

                if (codTecnicoSeleccionado == null)
                {
                    Response.Write("Seleccione un técnico");
                    return;
                }

                int idSolicitud = (int)Session["IdSolicitudSeleccionada"];
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                int duracion = negocio.ObtenerDuracionTrabajo(idSolicitud);
                DateTime fechaInicio = calFecha.SelectedDate;
                DateTime fechaFin = fechaInicio.AddDays(duracion);

                negocio.AsignarTecnico(idSolicitud, codTecnicoSeleccionado, fechaInicio, fechaFin);
                Response.Redirect("Gerente.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error, no se asignó trabajo: " + ex.Message);
            }
        }

        protected void repTecnicos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    dynamic dataItem = e.Item.DataItem;
                    RadioButton rb = (RadioButton)e.Item.FindControl("rbTecnico");
                    Label lbl = (Label)e.Item.FindControl("lblNombreTecnico");

                    // debug
                    Response.Write("CodTecnico: " + dataItem.CodTecnico + "<br/>");

                    // guardar CodTecnico
                    rb.ID = dataItem.CodTecnico;
                    rb.Attributes["value"] = dataItem.CodTecnico; //guardar valor xqe NO SE MANTENIA
                    lbl.Text = dataItem.Nombre + " " + dataItem.Apellido + " - " + dataItem.Localidad;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error carga de técnico: " + ex.Message);
            }
        }

    }

}