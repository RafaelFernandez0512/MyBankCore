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
    
    public partial class TLSMovimiento
    {
        public int Id { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public double MontoTransaccion { get; set; }
        public int IDCuenta { get; set; }
        public string Informacion { get; set; }
    }
}
