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
        string codTecnico = "";
        string usr = "";
        int nroDocumento = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int st = int.Parse(Request.QueryString["st"]);

            SolicitudTrabajoNegocio solicitudTrabajoNegocio = new SolicitudTrabajoNegocio();
            List<SolicitudTrabajo> listSolicitudesTrabajo = solicitudTrabajoNegocio.ListarAceptadas();
            SolicitudTrabajo stAux;
             
            stAux = listSolicitudesTrabajo.Find(x => x.Id == st);
            if (stAux != null)
            {
                lbl_nombreDetalle.Text = stAux.Nombre;
                lbl_apellidoDetalle.Text = stAux.Apellido;
                lbl_nroDocumentoDetalle.Text = stAux.Dni.ToString();
                lbl_provinciaDetalle.Text = stAux.Provincia;
                lbl_nroTelefonoDetalle.Text = stAux.Telefono.ToString();
                lbl_localidadDetalle.Text = stAux.Localidad;
                lbl_direccionDetalle.Text = stAux.Direccion;
                lbl_tipoTrabajoDetalle.Text = stAux.TipoTrabajo;
                lbl_descripcionDetalle.Text = stAux.Descripcion;
                lbl_cpDetalle.Text = "...";
                codTecnico = stAux.TecnicoAsignado;
            }
        }

        protected void btn_cerrarDetalle_Click(object sender, EventArgs e)
        {
            TecnicoNegocio tecnicoNegocio = new TecnicoNegocio();
            List<Dominio.Tecnico> listTecnicos = tecnicoNegocio.Listar();

            Dominio.Tecnico aux = listTecnicos.Find(x => x.CodTecnico == codTecnico);
            if (aux != null) 
            { 
                nroDocumento = aux.NroDocumento;
            }

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Dominio.Usuario> listUsuarios = usuarioNegocio.Listar();

            Dominio.Usuario auxUsr = listUsuarios.Find(x => x.NroDocumento == nroDocumento);
            if (auxUsr != null)
            {
                usr = auxUsr.usuario;
            }

            Response.Redirect("Tecnico.aspx?usr=" + usr, false);
        }

    }
}