//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoreWebServices.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TLSCliente
    {
        public int Id { get; set; }
        public long Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public System.DateTime Fecha { get; set; }
        public string EmpresaTrabajo { get; set; }
        public string PuestoTrabajo { get; set; }
        public double Sueldo { get; set; }
        public Nullable<int> Cuenta { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
    }
}
