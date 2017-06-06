using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketAtencion.Html
{
    public partial class Main : System.Web.UI.Page
    {
        [WebMethod]
        public static string ObtenerDato()
        {
            return new Conexion.ServicioTicket().ObtenerDato();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }   
}