using Newtonsoft.Json;
using System;
using System.Data;

namespace Negocio
{
    public class NTicket
    {
        public object ObtenerDato()
        {
            throw new NotImplementedException();
        }

        public string GetTicket() {
            try
            {
                Bdd.BTicket Ticket = new Bdd.BTicket();
                return JsonConvert.SerializeObject(new { resultado = true, data = Ticket});
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new { resultado = false, data = "Error el Traer los datos de ticket" });
            }
        }
    }
}
