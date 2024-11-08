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


                // Establece la fecha de carga actual en el TextBox
                txtFechaCarga.Text = DateTime.Now.ToString("dd/MM/yyyy");

         
                List<TipoTrabajo> tiposTrabajos = clienteNegocio.ListarTipos();

                ddlItems.DataSource = tiposTrabajos;
                ddlItems.DataValueField = "Nombre";
                ddlItems.DataBind();
                ddlItems.Items.Insert(0, new ListItem("Seleccione un tipo de trabajo", "0"));
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

            cliente.Documento=txtDni.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtNombre.Text.Split(' ').Length > 1 ? txtNombre.Text.Split(' ')[1] : ""; // para no sumar otra label y txtbox mas. Lo que hace aca es tomar la segunda parte del nombre ocmo apellido
            cliente.Telefono = int.Parse(txtTelefono.Text);
            cliente.Descripcion = txtObservaciones.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Localidad = txtLocalidad.Text;
            cliente.Provincia = txtProvincia.Text;
            cliente.Estado = 1;
            cliente.TipoTrabajo = ddlItems.SelectedItem.Text;

                int resultado = clienteNegocio.Agregar(cliente);

                if (resultado == 1)

            {
                    // Guardar los datos en la sesión
                    Session["Documento"] = cliente.Documento;
                    Session["Nombre"] = cliente.Nombre;
                    Session["Apellido"] = cliente.Apellido;
                    Session["Telefono"] = cliente.Telefono;
                    Session["Descripcion"] = cliente.Descripcion;
                    Session["Direccion"] = cliente.Direccion;
                    Session["Localidad"] = cliente.Localidad;
                    Session["Provincia"] = cliente.Provincia;
                    Session["Estado"] = cliente.Estado;
                    Session["TipoTrabajo"] = cliente.TipoTrabajo;
                    Session["FechaCarga"] = txtFechaCarga.Text;
                    Session["EsPresupuesto"] = flexRadioDefault1.Checked;
                    Session["EsReparacion"] = flexRadioDefault2.Checked;
                    Session["EsUrgente"] = flexSwitchCheckDefault.Checked;

                    LimpiarCampos();
                lblConfirmacion.Visible = true;
                // scrpit mensaje de éxito
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessage",
                    "alert('Solicitud guardada con éxito.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                "alert('El DNI ya existe en el sistema.');", true);
                }
            }
            catch (Exception ex)
            { // Mostrar mensaje de error
                ScriptManager.RegisterStartupScript(this, GetType(), "ShowError",
                    $"alert('Error al guardar la solicitud: {ex.Message}');", true);

                throw ;
            }


        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = clienteNegocio.GetCliente(txtDni.Text.Trim());
                if (cliente !=null)
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


        private void LimpiarCampos()
        {    //ya no podian ser mas null
            txtDni.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            ddlItems.SelectedIndex = 0;
        }
    }
}