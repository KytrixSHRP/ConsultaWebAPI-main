using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaWebAPI.Models
{
    public class Agendamento
    {
        public int IdAgendamento { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string EmailMedico { get; set; }
        public string EmailPaciente { get; set; }
    }
}