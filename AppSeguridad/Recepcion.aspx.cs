using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using Data_Management;

namespace AppSeguridad
{
    public partial class Clientes : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
         ClienteNegocio clienteNegocio;
         Cliente cliente;

        clienteNegocio = new ClienteNegocio();
        cliente = new Cliente();
       

            if (!IsPostBack)
            {
             
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
    }
}