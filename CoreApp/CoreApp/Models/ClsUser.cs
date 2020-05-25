using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Models
{
    public class ClsUser
    {
        [JsonProperty("idUsuario")]
        public int IDUsuario { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("contraseña")]
        public string Contraseña { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cedula")]
        public int Cedula { get; set; }

        [JsonProperty("tipoCuenta")]
        public string TipoCuenta { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("fecha_Creacion")]
        public DateTime FechaCreacion { get; set; }
     
    }
}
