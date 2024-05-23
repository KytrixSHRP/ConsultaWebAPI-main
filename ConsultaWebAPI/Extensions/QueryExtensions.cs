using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Extensions
{
    public static class QueryExtensions
    {
        public static string QueryInserirConsulta() => @"
        INSERT INTO consulta (agendamento_id, tipo_consulta_id, link_consulta) VALUES (@idAgendamento, 1, @urlConsulta);";

    }

}