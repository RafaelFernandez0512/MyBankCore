using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Models
{
   public class ClsTransaction
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("montoTransaccion")]
        public double MontoTransaccion { get; set; }

        [JsonProperty("idCuentaEmisor")]
        public int IdCuentaEmisor { get; set; }

        [JsonProperty("idCuentaReceptor")]
        public int IdCuentaReceptor { get; set; }

        [JsonProperty("tipoTransaccion")]
        public string TipoTransaccion { get; set; }

        [JsonProperty("descripción")]
        public string Descripción { get; set; }
    }
}
