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
                e.Day.IsSelectable = false; //selectablen't
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
        //cuando cambia seleccion tecnico
        protected void rbTecnico_CheckedChanged(object sender, EventArgs e)
        {
            
            RadioButton radioSeleccionado = (RadioButton)sender;
            //Session["CodigoTecnicoSeleccionado"] = radioSeleccionado.ID;
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
                        codTecnicoSeleccionado = rb.Attributes["codTecnico"];
                        break;
                    }
                }

                if (string.IsNullOrEmpty(codTecnicoSeleccionado))
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

                    rb.Attributes["codTecnico"] = dataItem.CodTecnico; // Mantiene bn el atrib
                    lbl.Text = dataItem.Apellido + ", " + dataItem.Nombre + " - " + dataItem.Localidad;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error carga de técnico: " + ex.Message);
            }
        }

    }

}