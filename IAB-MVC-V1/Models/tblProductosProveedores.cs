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
    
    public partial class tblProductosProveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProductosProveedores()
        {
            this.tblPresupuestos = new HashSet<tblPresupuestos>();
        }
    
        public int idProductoProveedor { get; set; }
        public Nullable<int> idServicioProveedor { get; set; }
        public string nombreProducto { get; set; }
        public Nullable<decimal> precioProducto { get; set; }
        public string descripcion { get; set; }
    
        public virtual tblServiciosProveedores tblServiciosProveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPresupuestos> tblPresupuestos { get; set; }
    }
}
