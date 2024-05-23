using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsultaWebAPI.Models
{
    public class MeetingUrl
    {
        [JsonPropertyName("join_url")]
        public string ConsultaUrl { get; set; }
    }
}