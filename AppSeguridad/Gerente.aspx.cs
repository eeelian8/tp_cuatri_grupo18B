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
    public partial class Gerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Recuperar los datos de la sesión
                string documento = Session["Documento"] as string;
                string nombre = Session["Nombre"] as string;
                string apellido = Session["Apellido"] as string;
                int telefono = Session["Telefono"] != null ? (int)Session["Telefono"] : 0;
                string descripcion = Session["Descripcion"] as string;
                string direccion = Session["Direccion"] as string;
                string localidad = Session["Localidad"] as string;
                string provincia = Session["Provincia"] as string;
                int estado = Session["Estado"] != null ? (int)Session["Estado"] : 0;
                string tipoTrabajo = Session["TipoTrabajo"] as string;

                // Recuperar valores adicionales
                string fechaCarga = Session["FechaCarga"] as string;
                bool esPresupuesto = Session["EsPresupuesto"] != null && (bool)Session["EsPresupuesto"];
                bool esReparacion = Session["EsREparacion"] != null && (bool)Session["EsREparacion"];
                bool esUrgente = Session["EsUrgente"] != null && (bool)Session["EsUrgente"];

                // Ejemplo de mostrar los valores en controles de etiqueta o `TextBox`
                lblDocumento.Text = documento;
                lblNombre.Text = nombre;
                lblApellido.Text = apellido;
                lblTelefono.Text = telefono.ToString();
                lblDescripcion.Text = descripcion;
                lblDireccion.Text = direccion;
                lblLocalidad.Text = localidad;
                lblProvincia.Text = provincia;
                lblTipoTrabajo.Text = tipoTrabajo;
                lblFechaCarga.Text = fechaCarga;
                lblEsPresupuesto.Text = esPresupuesto ? "Sí" : "No";
                lblEsUrgente.Text = esUrgente ? "Sí" : "No";
            }


        }
    }
}