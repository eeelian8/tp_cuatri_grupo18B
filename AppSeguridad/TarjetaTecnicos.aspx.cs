using System;
using Dominio;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSeguridad
{
    public partial class TarjetaTecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTarjetas();
            }
        }

        private void CargarTarjetas()
        {
            try
            {
                TarjetaTecnicosNegocio negocio = new TarjetaTecnicosNegocio();
                List<TarjetaTecnicos> listaTarjetas = negocio.ListarTarjetas();

                repTarjetas.DataSource = listaTarjetas;
                repTarjetas.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar el error, puedes mostrar un mensaje o registrar el log
                ScriptManager.RegisterStartupScript(this, GetType(), "ErrorAlert",
                    $"alert('Error al cargar tarjetas: {ex.Message}');", true);
            }
        }
    }
}
