using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdd
{
    public class BTicket
    {
        public string ObtenerDato()
        {
            Random a = new Random();
            int b = a.Next(0,50);
            return b.ToString() ;
        }
    }
}
