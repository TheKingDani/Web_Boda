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
    
    public partial class tblSeleccionarOfertas
    {
        public int idSeleccionOferta { get; set; }
        public Nullable<int> idOfertaProveedor { get; set; }
        public Nullable<int> idProveedor { get; set; }
    
        public virtual tblOfertasProveedores tblOfertasProveedores { get; set; }
        public virtual tblProveedores tblProveedores { get; set; }
    }
}