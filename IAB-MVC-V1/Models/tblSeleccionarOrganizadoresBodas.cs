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
    
    public partial class tblSeleccionarOrganizadoresBodas
    {
        public int IdSeleccionarOrganizadorBoda { get; set; }
        public Nullable<int> idNovios { get; set; }
        public Nullable<int> idOrganizadorBoda { get; set; }
    
        public virtual tblOrganizadoresBodas tblOrganizadoresBodas { get; set; }
        public virtual tblNovios tblNovios { get; set; }
    }
}
