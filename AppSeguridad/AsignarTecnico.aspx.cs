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

                    lbl.Text = dataItem.Nombre + " " + dataItem.Apellido + " - " + dataItem.Localidad;
                    rb.ID = dataItem.CodTecnico;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error carga de técnico: " + ex.Message);
            }
        }

    }

}