//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAiep.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HISTORIA
    {
        public decimal RESOLUTOR { get; set; }
        public decimal ID_TKT { get; set; }
        public Nullable<decimal> ID_RESOL_TER { get; set; }
        public System.DateTime FECHA_HIST { get; set; }
        public Nullable<System.TimeSpan> TIEMPO_HIST { get; set; }
        public string ESTADO_HIST { get; set; }
        public string NOTAS_HIST { get; set; }
        public string ATTACH_HIST { get; set; }
    
        public virtual RESOLUTORES_TERCEROS RESOLUTORES_TERCEROS { get; set; }
        public virtual TKT TKT { get; set; }
    }
}
