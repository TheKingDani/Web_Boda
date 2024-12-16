using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace IAB_MVC_V1.Models
{
    public class Usuario
    {
        public int usuarioID { get; set; } 
        public string email { get; set; } 
        public string password { get; set; } 
        public int tipoUsuarioID { get; set; }
    }
    
       
       
    }
    

