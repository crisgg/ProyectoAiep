using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Services;

namespace TicketAtencion.Conexion
{
    public class ServicioTicket
    {
        public string ObtenerDato() {
            var retornar = new Negocio.NTicket().ObtenerDato();
            return JsonConvert.SerializeObject(
            new
            {
                mensaje = retornar
            },
            Formatting.None,
            new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });
        }
    }
}