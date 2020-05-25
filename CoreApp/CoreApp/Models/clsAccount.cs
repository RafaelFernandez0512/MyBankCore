using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Models
{
    public class ClsAccount
    {
      
            [JsonProperty("$id")]
            public string Id { get; set; }

            [JsonProperty("idCuenta")]
            public int IdCuenta { get; set; }

            [JsonProperty("cedula")]
            public int Cedula { get; set; }

            [JsonProperty("tipoCuenta")]
            public string TipoCuenta { get; set; }

            [JsonProperty("balance")]
            public double Balance { get; set; }

            [JsonProperty("fechaActualizacion")]
            public DateTime FechaActualizacion { get; set; }

            [JsonProperty("fechaCreacion")]
            public DateTime FechaCreacion { get; set; }
     
    }
}
