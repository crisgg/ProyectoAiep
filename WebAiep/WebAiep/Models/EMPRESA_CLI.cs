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
    
    public partial class EMPRESA_CLI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPRESA_CLI()
        {
            this.SERVICIO_EMPRESA = new HashSet<SERVICIO_EMPRESA>();
            this.USUARIO_FINAL = new HashSet<USUARIO_FINAL>();
        }
    
        public Nullable<decimal> ID_EMPRESA_PROV { get; set; }
        public decimal ID_EMPRESA { get; set; }
        public Nullable<decimal> ID_COMUNA { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string DIRECCION_EMPRESA { get; set; }
    
        public virtual COMUNAS COMUNAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO_EMPRESA> SERVICIO_EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_FINAL> USUARIO_FINAL { get; set; }
    }
}
