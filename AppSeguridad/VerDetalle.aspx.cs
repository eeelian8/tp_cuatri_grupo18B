using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSeguridad
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int st = int.Parse(Request.QueryString["st"]);

            SolicitudTrabajoNegocio solicitudTrabajoNegocio = new SolicitudTrabajoNegocio();
            List<SolicitudTrabajo> listSolicitudesTrabajo = solicitudTrabajoNegocio.ListarPendientes();
            SolicitudTrabajo stAux;
             
            stAux = listSolicitudesTrabajo.Find(x => x.Id == st);
            if (stAux != null)
            {
                lbl_Nombre.Text = stAux.Nombre;
                lbl_Apellido.Text = stAux.Apellido;
                lbl_Documento.Text = stAux.Dni.ToString();
                lbl_Provincia.Text = stAux.Provincia;
                lbl_Localidad.Text = stAux.Localidad;
                lbl_Direccion.Text = stAux.Direccion;
                lbl_TipoTrabajo.Text = stAux.TipoTrabajo;
            }
        }
    }
}