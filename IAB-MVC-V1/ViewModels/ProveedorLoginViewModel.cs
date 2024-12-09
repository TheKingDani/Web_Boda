using IAB_MVC_V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IAB_MVC_V1.ViewModels
{
    public class ProveedorLoginViewModel
    {
        public LoginViewModel LoginModel { get; set; }
        public tblProveedores ProveedorModel { get; set; }
    }
}