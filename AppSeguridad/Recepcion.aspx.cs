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
            List<TipoTrabajo> tiposTrabajos = clienteNegocio.ListarTipos();
            ddlItems.DataSource = tiposTrabajos;
            ddlItems.DataValueField = "Nombre";
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem("Seleccione un tipo de trabajo", "0"));
        }
        private void CargarHistorialTrabajos()
        {
            try
            {
                DataTable dtHistorial = clienteNegocio.ObtenerHistorialTrabajos();

                dgvHistorial.DataSource = dtHistorial;
                dgvHistorial.DataBind();

                // Opcional: Mostrar mensaje si no hay datos
                if (dtHistorial.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowInfo",
                        "alert('No hay registros para mostrar.');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.Documento = txtDni.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtNombre.Text.Split(' ').Length > 1 ? txtNombre.Text.Split(' ')[1] : "";

                // Validar el campo teléfono
                if (int.TryParse(txtTelefono.Text, out int telefono))
                {
                    cliente.Telefono = telefono;
                }
                else
                {
                    // Mostrar un mensaje de error si el formato no es válido
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                        "alert('El campo Teléfono debe contener solo números.');", true);
                    return; // Salir del método para evitar un fallo.
                }

                cliente.Descripcion = txtObservaciones.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Localidad = txtLocalidad.Text;
                cliente.Provincia = txtProvincia.Text;
                cliente.Estado = 1;
                cliente.TipoTrabajo = ddlItems.SelectedItem.Text;

                int resultado = clienteNegocio.Agregar(cliente);

                if (resultado == 1)
                {

                    lblConfirmacion.Visible = true;
                    lblConfirmacion.Text = "Solicitud enviada con éxito."; // Asegúrate de que tenga texto
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
                throw;
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
                    // Mostrar la alerta si el DNI no existe
                    alertaDniNoExiste.Visible = true;
                    //script para que aparezca el cartel 5 segundos
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
                    dgvHistorialCliente.DataSource = dtHistorialCliente;
                    dgvHistorialCliente.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowHistorialClienteModal", "showHistorialClienteModal();", true);
                    UpdatePanel2.Update();
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
        protected void dgvHistorial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            dgvHistorial.PageIndex = e.NewPageIndex;
            CargarHistorialTrabajos();
            UpdatePanel1.Update();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                $"alert('Error al cambiar de página: {ex.Message}');", true);
        }
    }


    }
}