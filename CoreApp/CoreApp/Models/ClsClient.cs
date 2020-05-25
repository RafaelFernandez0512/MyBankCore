using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Models
{
    public class ClsClient
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cedula")]
        public int IdCard { get; set; }

        [JsonProperty("nombre")]
        public string Name { get; set; }

        [JsonProperty("apellido")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("sexo")]
        public string Gender { get; set; }

        [JsonProperty("fecha")]
        public DateTime Date_Time { get; set; }

        [JsonProperty("empresaTrabajo")]
        public string JobCompany { get; set; }

        [JsonProperty("puestoTrabajo")]
        public string WorkStation { get; set; }

        [JsonProperty("sueldo")]
        public double Salary { get; set; }

        [JsonProperty("cuenta")]
        public int Account { get; set; }

        [JsonProperty("fecha_Creacion")]
        public DateTime FechaCreacion { get; set; }

    }
}
