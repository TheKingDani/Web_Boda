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
    
    public partial class tblTipoInvitado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTipoInvitado()
        {
            this.tblInvitados = new HashSet<tblInvitados>();
        }
    
        public int idTipoInvitado { get; set; }
        public string tipoInvitado { get; set; }
        public string tituloCorreo { get; set; }
        public string descripcion { get; set; }
        public string archivoBienvenida { get; set; }
        public Nullable<int> idNoviosTI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInvitados> tblInvitados { get; set; }
        public virtual tblNovios tblNovios { get; set; }
    }
}
