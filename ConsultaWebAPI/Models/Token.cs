using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsultaWebAPI.Models
{
    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}