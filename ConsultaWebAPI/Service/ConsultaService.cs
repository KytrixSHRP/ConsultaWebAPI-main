using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;
using ConsultaWebAPI.Repository;

namespace ConsultaWebAPI.Service
{
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaDatabase _consultaDatabase;
        public ConsultaService(IConsultaDatabase consultaDatabase)
        {
            _consultaDatabase = consultaDatabase;
        }
        public async Task<bool> CriarConsulta(Agendamento agendamento,string linkConsulta)
        {
            var consultaCriada = await _consultaDatabase.InserirConsulta(agendamento, linkConsulta);
            return consultaCriada;
        }
    }
}