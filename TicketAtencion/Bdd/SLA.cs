//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bdd
{
    using System;
    using System.Collections.Generic;
    
    public partial class SLA
    {
        public decimal ID_SLA { get; set; }
        public Nullable<decimal> ID_ALERTA { get; set; }
        public Nullable<decimal> ID_SERVI_EMP { get; set; }
        public string NOMBRE_SLA { get; set; }
        public byte IMPORTANCIA_SLA { get; set; }
        public string URGENCIA_SLA { get; set; }
        public string IMPACTO_SLA { get; set; }
    
        public virtual ALERTAS ALERTAS { get; set; }
        public virtual SERVICIO_EMPRESA SERVICIO_EMPRESA { get; set; }
    }
}