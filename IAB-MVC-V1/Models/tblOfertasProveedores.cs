//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IAB_MVC_V1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOfertasProveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOfertasProveedores()
        {
            this.tblSeleccionarOfertas = new HashSet<tblSeleccionarOfertas>();
        }
    
        public int idOfertaProveedor { get; set; }
        public Nullable<decimal> oferta { get; set; }
        public Nullable<bool> estatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSeleccionarOfertas> tblSeleccionarOfertas { get; set; }
    }
}