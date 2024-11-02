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

        // guardar motivo rechazo.                                                                                  v
        protected string motivoRechazo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTecnicos();
        }

        private void CargarTecnicos()
        {
            try
            {
                TecnicoNegocio negocio = new TecnicoNegocio();
                List<Tecnico> lista = negocio.Listar();

                repTareas.DataSource = lista;
                repTareas.DataBind();

                //botones deshabilitados
                btnAceptar.Enabled = false;
                btnDenegar.Enabled = false;
                btnAceptar.CssClass = "btn btn-secondary px-4";
                btnDenegar.CssClass = "btn btn-secondary px-4";
            }
            catch (Exception ex)
            {
                Response.Write("Error al cargar técnicos: " + ex.Message);
            }
        }

        protected void tareaSeleccionada(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //habilitar tecnicos
                btnAceptar.Enabled = true;
                btnDenegar.Enabled = true;
                btnAceptar.CssClass = "btn btn-success px-4";
                btnDenegar.CssClass = "btn btn-danger px-4";
                //guardar tarea seleccionada
                string idTareaSeleccionada = e.CommandArgument.ToString();

                //marcar elemento seleccionado
                foreach (RepeaterItem item in repTareas.Items)
                {
                    LinkButton link = (LinkButton)item.FindControl("lnkTrabajo");
                    if (link != null)
                    {
                        if (link.CommandArgument == idTareaSeleccionada)
                            link.CssClass = "list-group-item list-group-item-action active";
                        else
                            link.CssClass = "list-group-item list-group-item-action";
                    }
                }
            }
        }

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



    }
}

