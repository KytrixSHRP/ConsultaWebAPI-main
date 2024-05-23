using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;

namespace ConsultaWebAPI.Repository
{
    public interface IConsultaDatabase
    {
        public Task<bool> InserirConsulta(Agendamento agendamento, string url);
    }
}