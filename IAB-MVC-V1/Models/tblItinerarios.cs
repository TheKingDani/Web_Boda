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
    
    public partial class tblItinerarios
    {
        public int idItinerario { get; set; }
        public Nullable<int> idNovios { get; set; }
        public Nullable<System.DateTime> horaInicio { get; set; }
        public Nullable<System.DateTime> horaFin { get; set; }
        public string actividad { get; set; }
        public string responsables { get; set; }
    
        public virtual tblNovios tblNovios { get; set; }
    }
}
