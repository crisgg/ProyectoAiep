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
    
    public partial class CALENDARIO
    {
        public decimal ID_FERIADO { get; set; }
        public Nullable<decimal> ID_PAIS { get; set; }
        public Nullable<System.DateTime> FECHA_NO_LABORAL { get; set; }
        public string DESCRIPCION_NO_LABORAL { get; set; }
    
        public virtual PAISES PAISES { get; set; }
    }
}
