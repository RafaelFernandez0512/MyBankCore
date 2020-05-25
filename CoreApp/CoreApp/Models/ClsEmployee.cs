using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApp.Models
{
    public class ClsEmployee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cedula")]
        public int Cedula { get; set; }

        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }

        [JsonProperty("fecha_Creacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("idDepartamento")]
        public string IdDepartamento { get; set; }

        [JsonProperty("puesto")]
        public string Puesto { get; set; }

        [JsonProperty("horario")]
        public string Horario { get; set; }

        [JsonProperty("sueldo")]
        public double Sueldo { get; set; }

        [JsonProperty("perfil")]
        public string Perfil { get; set; }

        [JsonProperty("sexo")]
        public string Sexo { get; set; }
    }
}
