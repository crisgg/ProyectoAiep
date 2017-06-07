using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdd
{
    public class BTicket
    {
        public List<TKT> GetTicket() {
            return new List<TKT>();
        }
        
        public List<TKT> GetTicketPorId(string value)
        {
            decimal a = decimal.Parse(value);
            List<TKT> bd = new List<TKT>().Where(x => x.ID_LOGIN == a).ToList();
            return bd;
        }

        public void SetTicket
            (
             Nullable<decimal> ID_URGENCIA,
             Nullable<decimal> ID_ESTADO,
             Nullable<decimal> ID_IMPACTO,
             Nullable<decimal> ID_TIPO,
             Nullable<decimal> ID_LOGIN,
             Nullable<decimal> ID_SERVI_EMP,
             int CREADOR_TKT,
             short REPORTADOR_TKT,
             string AFECTADO_TKT,
             int PRIORIDAD_TKT,
             byte VALOR_IMPACTO_TKT,
             byte VALOR_URGENCIA_TKT,
             string RUT_EMPRESA_PROV,
             ESTADOS ESTADOS,
              ICollection<HISTORIA> HISTORIA,
             IMPACTO IMPACTO,
             LOGIN LOGIN,
             SERVICIO_EMPRESA SERVICIO_EMPRESA,
             TIPIFICACION TIPIFICACION,
             URGENCIA URGENCIA
            )
        {
            TKT dtt = new TKT();
            dtt.ID_ESTADO = ID_ESTADO;
            dtt.ID_IMPACTO = ID_IMPACTO;
            dtt.ID_TIPO = ID_TIPO;
            dtt.ID_LOGIN = ID_LOGIN;
            dtt.ID_SERVI_EMP = ID_SERVI_EMP;
            dtt.CREADOR_TKT = CREADOR_TKT;
            dtt.REPORTADOR_TKT = REPORTADOR_TKT;
            dtt.AFECTADO_TKT = AFECTADO_TKT;
            dtt.PRIORIDAD_TKT = PRIORIDAD_TKT;
            dtt.VALOR_IMPACTO_TKT = VALOR_IMPACTO_TKT;
            dtt.VALOR_URGENCIA_TKT = VALOR_URGENCIA_TKT;
            dtt.RUT_EMPRESA_PROV = RUT_EMPRESA_PROV;
            dtt.ESTADOS = ESTADOS;
            dtt.HISTORIA = HISTORIA;
            dtt.IMPACTO = IMPACTO;
            dtt.LOGIN = LOGIN;
            dtt.SERVICIO_EMPRESA = SERVICIO_EMPRESA;
            dtt.TIPIFICACION = TIPIFICACION;
            dtt.URGENCIA = URGENCIA;
            var sql = new Collection<TKT>();
            sql.Add(dtt);            
        }

    }                       
}                           
                            