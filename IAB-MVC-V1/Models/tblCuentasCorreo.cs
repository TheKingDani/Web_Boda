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
    
    public partial class tblCuentasCorreo
    {
        public int idCuentaCorreo { get; set; }
        public Nullable<int> idNovios { get; set; }
        public string smtpServidor { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public Nullable<int> port { get; set; }
    
        public virtual tblNovios tblNovios { get; set; }
    }
}