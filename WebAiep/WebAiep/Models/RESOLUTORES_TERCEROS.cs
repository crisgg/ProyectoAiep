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
    
    public partial class RESOLUTORES_TERCEROS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESOLUTORES_TERCEROS()
        {
            this.HISTORIA = new HashSet<HISTORIA>();
            this.TELS_RESOL_TER = new HashSet<TELS_RESOL_TER>();
        }
    
        public decimal ID_RESOL_TER { get; set; }
        public Nullable<decimal> ID_COMUNA { get; set; }
        public string NOM_RESOL_TER { get; set; }
        public string RSOCIAL_RESOL_TER { get; set; }
        public string RUT_RESOL_TER { get; set; }
        public string DIRECCION_RESOL_TER { get; set; }
    
        public virtual COMUNAS COMUNAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORIA> HISTORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELS_RESOL_TER> TELS_RESOL_TER { get; set; }
    }
}
