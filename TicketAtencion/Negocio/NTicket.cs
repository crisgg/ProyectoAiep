using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Negocio
{
    public class NTicket
    {
        public string ObtenerDato() {
            try
            {
                return new Bdd.BTicket().ObtenerDato();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ha ocurrido un problema con la Consulta, Error: {0}", ex));
            }
        }
    }
}
