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
                calendarioFecha.SelectedDate = DateTime.Today; //solo fecha desde hoy
                
                CargarTecnicosDisponibles();
                CargarDataTarea();
            }
        }

        private void CargarDataTarea()
        {
            try
            {
                if (Session["IdSolicitudSeleccionada"] != null)
                {
                    int idSolicitud = (int)Session["IdSolicitudSeleccionada"];
                    SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                    SolicitudTrabajo solicitud = negocio.Buscar(idSolicitud);

                    if (solicitud != null)
                    {
                        lblTT.Text = solicitud.TipoTrabajo;
                        lblCliente.Text = solicitud.Nombre;
                        lblTelefono.Text = solicitud.Telefono.ToString();
                        lblDireccion.Text = solicitud.Direccion + ", " + solicitud.Localidad;

                        lblDescripcion.Text = solicitud.Descripcion;

                        int duracionDias = negocio.ObtenerDuracionTrabajo(idSolicitud);
                        lblDuracion.Text = duracionDias + " dias";
                    }
                    else
                    {
                        Response.Write("Solicitud es null");
                    }

                }
                
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar detalles de la tarea: " + ex.Message);
            }
        }

        protected void calendarioFecha_DayRender(object sender, DayRenderEventArgs dia)
        {
            try
            {

                // Deshabilitar fechas pasadas
                if (dia.Day.Date < DateTime.Today)
                {
                    dia.Day.IsSelectable = false; //selectablen't
                    dia.Cell.ForeColor = System.Drawing.Color.Gray;
                }

                int idSolicitud = (int)Session["IdSolicitudSeleccionada"];
                SolicitudTrabajoNegocio negocio = new SolicitudTrabajoNegocio();
                int duracionTrabajo = negocio.ObtenerDuracionTrabajo(idSolicitud);

                DateTime fechaFin = calendarioFecha.SelectedDate.AddDays(duracionTrabajo - 1);
                if (dia.Day.Date == calendarioFecha.SelectedDate)
                {

                    dia.Cell.BackColor = System.Drawing.Color.LightCyan;
                    dia.Cell.ForeColor = System.Drawing.Color.Black;
                }
                if (dia.Day.Date > calendarioFecha.SelectedDate && dia.Day.Date <= fechaFin)
                {
                    dia.Cell.BackColor = System.Drawing.Color.LightBlue;
                    dia.Cell.ForeColor = System.Drawing.Color.Black;

                }
            }

            catch (Exception ex)
            {
                Response.Write("error de coloreo calendario: " + ex.Message);
            }

        }

        protected void calendarioFecha_SelectionChanged(object sender, EventArgs e)
        {
            CargarTecnicosDisponibles(); 
        }

        private void CargarTecnicosDisponibles()
        {
            try
            {
                int idSolicitud = (int)Session["IdSolicitudSeleccionada"];
                SolicitudTrabajoNegocio solicitudNegocio = new SolicitudTrabajoNegocio();
                int duracionDias = solicitudNegocio.ObtenerDuracionTrabajo(idSolicitud);

                TecnicoNegocio tecnoNegocio = new TecnicoNegocio();
                repTecnicos.DataSource = tecnoNegocio.ListarTecnicosDisponibles(calendarioFecha.SelectedDate, duracionDias);
                repTecnicos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("error al mostrar tecnicos disponibles" + ex.Message);
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
                DateTime fechaInicio = calendarioFecha.SelectedDate;
                DateTime fechaFin = fechaInicio.AddDays(duracion);

                negocio.AsignarTecnico(idSolicitud, codTecnicoSeleccionado, fechaInicio, fechaFin);

                lbAvisoExito.Visible = true;///inspirado de recepcion
                Response.AddHeader("REFRESH","3;URL=Gerente.aspx");
                /// agrega en el HTTP  el URL con una espera de 3 segs y refresque
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
                if (e.Item.DataItem != null)
                {
                    dynamic dataItem = e.Item.DataItem;
                    RadioButton rb = (RadioButton)e.Item.FindControl("rbTecnico");
                    Label lbl = (Label)e.Item.FindControl("lblNombreTecnico");
                    Label lblCelular = (Label)e.Item.FindControl("lblCelular");
                    Label lblCodigo = (Label)e.Item.FindControl("lblCodigo");
                    Label lblLocalidad = (Label)e.Item.FindControl("lblLocalidad");

                    rb.Attributes["codTecnico"] = dataItem.CodTecnico; // Mantiene bn el atrib
                    lbl.Text = dataItem.Apellido + ", " + dataItem.Nombre;
                    lblCelular.Text = dataItem.Celular.ToString();
                    lblCodigo.Text = dataItem.CodTecnico;
                    lblLocalidad.Text = dataItem.Localidad;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error carga de técnico: " + ex.Message);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gerente.aspx");
        }

    }

}