using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Extensions;
using ConsultaWebAPI.Models;
using Dapper;
using MySqlConnector;

namespace ConsultaWebAPI.Repository
{
    public class ConsultaDatabase : IConsultaDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<ConsultaDatabase> _logger;
        
        public ConsultaDatabase (MySqlConnection database, ILogger<ConsultaDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public async Task<bool> InserirConsulta(Agendamento agendamento, string url)
        {
            try
            {
                _logger.LogInformation($"Tentando cadastrar o agendamento no sistema...");
                
                await _database.ExecuteAsync(QueryExtensions.QueryInserirConsulta(),
                new {
                    idAgendamento= agendamento.IdAgendamento,
                    urlConsulta = url
                });

                return true;
            }

            catch(MySqlException mysqlEx){
                _logger.LogError($"Não foi possível cadastrar o agendamento: {mysqlEx.ErrorCode} {mysqlEx.Message}");
                return false;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}