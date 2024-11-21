using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSeguridad
{
    public partial class TarjetaTecnicos : System.Web.UI.Page
    {
        public List<Dominio.Tecnico> ListaTecnicos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarTecnicos();
            }
        }

        private void cargarTecnicos()
        {
            TecnicoNegocio negocio = new TecnicoNegocio();
            ListaTecnicos = negocio.ListarTecnicos();
        }
    }
}