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
    
    public partial class TLSEmpleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public long Cedula { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        public int IdDepartamento { get; set; }
        public string Puesto { get; set; }
        public string Horario { get; set; }
        public double Sueldo { get; set; }
        public string Perfil { get; set; }
        public string Sexo { get; set; }
    }
}
