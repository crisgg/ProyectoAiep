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
    
    public partial class HIJOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HIJOS()
        {
            this.AGENTES = new HashSet<AGENTES>();
        }
    
        public decimal ID_HIJO { get; set; }
        public string NOMBRE_HIJO { get; set; }
        public byte EDAD_HIJO { get; set; }
        public System.DateTime NAC_HIJO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AGENTES> AGENTES { get; set; }
    }
}
