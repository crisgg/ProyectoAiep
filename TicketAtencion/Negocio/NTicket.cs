using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.Entity;

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
                return JsonConvert.SerializeObject(new { resultado = true, data = new Bdd.BTicket().GetTicket()});
            }
            catch (Exception)
            {
                return JsonConvert.SerializeObject(new { resultado = false, data = "Error el Traer los datos de ticket" });
            }
        }
    }
}
