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
    
    public partial class TIPIFICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPIFICACION()
        {
            this.TIPIFICACION1 = new HashSet<TIPIFICACION>();
            this.TKT = new HashSet<TKT>();
        }
    
        public decimal ID_TIPO { get; set; }
        public Nullable<decimal> ID_TIPO_PADRE { get; set; }
        public string NOMBRE_TIPO { get; set; }
        public int NIVEL_TIPO { get; set; }
        public Nullable<decimal> ID_EMPRESA_PROV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIPIFICACION> TIPIFICACION1 { get; set; }
        public virtual TIPIFICACION TIPIFICACION2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TKT> TKT { get; set; }
    }
}
