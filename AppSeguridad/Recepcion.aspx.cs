using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Data_Management;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace AppSeguridad
{
    public partial class Clientes : System.Web.UI.Page
    {
        
        RecepcionNegocio clienteNegocio;
        Recepcion cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            clienteNegocio = new RecepcionNegocio();
            cliente = new Recepcion();

            if (!IsPostBack)
            {
                txtFechaCarga.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarTiposTrabajos();
                CargarHistorialTrabajos();
            }
        }

        private void CargarTiposTrabajos()
        {
            try
            {
                List<TipoTrabajo> tiposTrabajos = clienteNegocio.ListarTipos();

                ddlItems.DataSource = tiposTrabajos;
                ddlItems.DataValueField = "Id";
                ddlItems.DataTextField = "Nombre";
                ddlItems.DataBind();

                // Agregar item por defecto
                ddlItems.Items.Insert(0, new ListItem("Seleccione un tipo de trabajo", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cargar tipos de trabajo: {ex.Message}');", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.Documento = txtDni.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtNombre.Text.Split(' ').Length > 1 ? txtNombre.Text.Split(' ')[1] : "";

                if (int.TryParse(txtTelefono.Text, out int telefono))
                {
                    cliente.Telefono = telefono;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('El campo Teléfono debe contener solo números.');", true);
                    return;
                }

                // Valida que se haya seleccionado un tipo de trabajo
                if (ddlItems.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('Por favor seleccione un tipo de trabajo.');", true);
                    return;
                }

                cliente.Descripcion = txtObservaciones.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Localidad = txtLocalidad.Text;
                cliente.Provincia = txtProvincia.Text;
                cliente.Estado = 1;
                cliente.TipoTrabajo = ddlItems.SelectedItem.Text;
                cliente.IdTipoTrabajo = Convert.ToInt32(ddlItems.SelectedValue); //ya estaba correcto

                int resultado = clienteNegocio.Agregar(cliente);

                if (resultado == 1)
                {
                    lblConfirmacion.Visible = true;
                    lblConfirmacion.Text = "Solicitud enviada con éxito.";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('Hubo un problema al guardar la solicitud. Intente nuevamente.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al guardar la solicitud: {ex.Message}');", true);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = clienteNegocio.GetCliente(txtDni.Text.Trim());
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono.ToString();
                    txtDireccion.Text = cliente.Direccion;
                    txtLocalidad.Text = cliente.Localidad;
                    txtProvincia.Text = cliente.Provincia;
                    alertaDniNoExiste.Visible = false;
                }
                else
                {
                    LimpiarCampos();
                    alertaDniNoExiste.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "HideAlert", "hideAlertAfterTimeout();", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                CargarHistorialTrabajos();
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowHistorialModal", "showHistorialModal();", true);
                UpdatePanel1.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cargar el historial: {ex.Message}');", true);
            }
        }

        protected void btnHistorialCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = txtDni.Text.Trim();

                if (string.IsNullOrEmpty(dni))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('Por favor, ingrese un DNI para ver el historial del cliente.');", true);
                    return;
                }

                DataTable dtHistorialCliente = clienteNegocio.ObtenerHistorialCliente(dni);

                if (dtHistorialCliente.Rows.Count > 0)
                {
                    GridView dgvHistorialCliente = (GridView)UpdatePanel2.FindControl("dgvHistorialCliente");
                    if (dgvHistorialCliente != null)
                    {
                        dgvHistorialCliente.DataSource = dtHistorialCliente;
                        dgvHistorialCliente.DataBind();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowHistorialClienteModal",
                            "showHistorialClienteModal();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                            "alert('Error al encontrar el control de la grilla.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('No se encontraron registros para este cliente.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cargar el historial del cliente: {ex.Message}');", true);
            }
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFiltroId.Text) && int.TryParse(txtFiltroId.Text, out int idSolicitud))
                {
                    DataTable dtFiltrado = clienteNegocio.ObtenerHistorialTrabajosPorId(idSolicitud);

                    if (dtFiltrado.Rows.Count > 0)
                    {
                        // Verificar si hay reportes usando la columna CantidadReportes
                        int cantidadReportes = Convert.ToInt32(dtFiltrado.Rows[0]["CantidadReportes"]);

                        dgvHistorial.DataSource = dtFiltrado;
                        dgvHistorial.DataBind();

                        // Muestra mensaje si no hay reportes
                        if (cantidadReportes == 0)
                        {
                            string script = @"
                        if(confirm('La solicitud no tiene reportes técnicos asociados. ¿Desea continuar viendo los detalles?')) {
                            return true;
                        } else {
                            return false;
                        }";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowNoReportesMessage", script, true);
                        }
                    }
                    else
                    {
                        // Por si nose encontró la solicitud
                        string script = @"alert('No se encontró la solicitud con el ID especificado.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowNotFoundMessage", script, true);
                    }
                }
                else
                {
                    // ID inválido
                    string script = @"alert('Por favor, ingrese un ID válido.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowInvalidIdMessage", script, true);
                }
            }
            catch (Exception ex)
            {
                string script = $"alert('Error al filtrar: {ex.Message}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowErrorMessage", script, true);
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroId.Text = string.Empty;
            CargarHistorialTrabajos();
        }
        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistorial.SelectedRow != null)
                {
                    int idSolicitud = Convert.ToInt32(dgvHistorial.SelectedRow.Cells[0].Text);
                    CargarReportes(idSolicitud);

                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowReportesModal",
                        "$('#modalReportes').modal('show');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('Por favor, seleccione una solicitud primero.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cargar reportes: {ex.Message}');", true);
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlPageSize = (DropDownList)sender;
                dgvHistorial.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
                CargarHistorialTrabajos();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cambiar el tamaño de página: {ex.Message}');", true);
            }
        }

        private void CargarReportes(int idSolicitud)
        {
            try
            {
                DataTable dtReportes = clienteNegocio.ObtenerReportesTrabajo(idSolicitud);
                GridView dgvReportes = UpdatePanel1.FindControl("dgvReportes") as GridView;
                if (dgvReportes != null)
                {
                    dgvReportes.DataSource = dtReportes;
                    dgvReportes.DataBind();

                    if (dtReportes.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowInfo",
                            "alert('No hay reportes disponibles para esta solicitud.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvHistorial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvHistorial.PageIndex = e.NewPageIndex;
                if (!string.IsNullOrEmpty(txtFiltroId.Text))
                {
                    btnFiltrar_Click(sender, e);
                }
                else
                {
                    CargarHistorialTrabajos();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cambiar de página: {ex.Message}');", true);
            }
        }
        private void LimpiarCampos()
        {
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            ddlItems.SelectedIndex = 0;
        }

        private void CargarHistorialTrabajos()
        {
            try
            {
                DataTable dtHistorial = clienteNegocio.ObtenerHistorialTrabajos();
                dgvHistorial.DataSource = dtHistorial;
                dgvHistorial.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnVerReportes_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idTrabajo = Convert.ToInt32(btn.CommandArgument);

                // Obtener reportes del trabajo específico
                DataTable dtReportes = clienteNegocio.ObtenerReportesTrabajo(idTrabajo);

                if (dtReportes.Rows.Count > 0)
                {
                    dgvReportes.DataSource = dtReportes;
                    dgvReportes.DataBind();

                    // Mostrar el modal
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowReportesModal",
                        "$('#modalReportes').modal('show');", true);
                }
                else
                {
                    // Mostrar mensaje si no hay reportes
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowNoReportesMessage",
                        "alert('No hay reportes técnicos para este trabajo.');", true);
                }

                // Actualizar el panel que contiene la grilla de reportes
                UpdatePanel3.Update();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al cargar los reportes: {ex.Message}');", true);
            }
        }
    }
}