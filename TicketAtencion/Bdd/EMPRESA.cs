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
    
    public partial class EMPRESA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPRESA()
        {
            this.HITOS_NO_LABORALES = new HashSet<HITOS_NO_LABORALES>();
            this.HORAS_TURNOS = new HashSet<HORAS_TURNOS>();
            this.SERVICIO = new HashSet<SERVICIO>();
            this.TELS_EMPRESA = new HashSet<TELS_EMPRESA>();
        }
    
        public string RUT_EMPRESA_PROV { get; set; }
        public Nullable<decimal> ID_PAIS { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string RAZON_SOCIAL_EMPRESA { get; set; }
        public string DIRECCION_EMPRSA { get; set; }
    
        public virtual PAISES PAISES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HITOS_NO_LABORALES> HITOS_NO_LABORALES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HORAS_TURNOS> HORAS_TURNOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVICIO> SERVICIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TELS_EMPRESA> TELS_EMPRESA { get; set; }
    }
}
