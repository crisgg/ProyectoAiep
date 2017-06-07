using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transferencia
{
    public class TTicket
    {
        int idTkt { get; set; }
        int idUrgencia { get; set; }
        int idEstado { get; set; }
        int idImpacto { get; set; }
        int idTipo { get; set; }
        int idLogin { get; set; }
        int idServiEmp { get; set; }
        int creador { get; set; }
        int reportdor { get; set; }
        string afectdo { get; set; }
        int prioridad { get; set; }
        byte valorImpacto { get; set; }
        byte valorUrgencia { get; set; }
        string rutEmpresaProv { get; set; }
        List<string> estados { get; set; }
        List<string> historia { get; set; }
        List<string> impacto { get; set; }
        List<string> login { get; set; }
        List<Object> servicioEmpresa { get; set; }
        List<Object> tipificacion { get; set; }
        List<Object> urgencia { get; set; }


    }
}
