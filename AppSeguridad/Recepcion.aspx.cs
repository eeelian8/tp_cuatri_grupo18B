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

                ddlItems.Items.Add(new ListItem("CERCOS ELECTRICOS", "1"));
                ddlItems.Items.Add(new ListItem("ALARMAS", "2"));
                ddlItems.Items.Add(new ListItem("CAMARAS", "3"));
                ddlItems.Items.Add(new ListItem("PORTONES AUTOMATICOS", "4"));
                ddlItems.Items.Add(new ListItem("PORTEROS ELECTRICOS", "5"));
                ddlItems.Items.Add(new ListItem("CERRAJERIA", "6"));
                ddlItems.Items.Add(new ListItem("ELECTRICIDAD", "7"));
                ddlItems.Items.Add(new ListItem("VARIOS", "8"));
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string observaciones = txtObservaciones.Text;


            Response.Write($"Nombre: {nombre},Direccion: {direccion}, Telefono: {telefono},Observaciones:{observaciones}");
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

        }
        protected void DNIUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cliente = clienteNegocio.GetCliente(txtDni.Text.Trim());
                if (cliente!=null)
                {
                    
                    txtNombre.Text = cliente.Nombre;
                    txtTelefono.Text = cliente.Telefono.ToString();
                    txtDireccion.Text = cliente.Direccion;
                    txtLocalidad.Text = cliente.Localidad;
                    txtProvincia.Text = cliente.Provincia;

                }
                else
                {// Mostrar la alerta si el DNI no existe
                    alertaDniNoExiste.Visible = true;
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = null;
            txtTelefono.Text = null;
            txtDireccion.Text = null;
            txtLocalidad.Text = null;
            txtProvincia.Text = null;
        }
    }
}