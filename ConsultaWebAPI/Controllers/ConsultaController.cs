using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;
using ConsultaWebAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace AgendamentoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultaController : Controller
    {
        private readonly ILogger<ConsultaController> _logger;

        private readonly ITokenService _tokenService;

        private readonly IZoomMeetingService _zoomMeetingService;

        private readonly IConsultaService _consultaService;

        public ConsultaController(ILogger<ConsultaController> logger, ITokenService tokenService, IZoomMeetingService zoomMeetingService, IConsultaService consultaService)
        {
            _logger = logger;
            _tokenService = tokenService;            
            _zoomMeetingService = zoomMeetingService;
            _consultaService = consultaService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostConsulta([FromBody] Agendamento agendamento){
            var token = await _tokenService.GetToken();
            
            var consultaUrl = await _zoomMeetingService.GerarConsultaZoom(agendamento, token.AccessToken);
            
            var consultaCriada = await _consultaService.CriarConsulta(agendamento, consultaUrl);

            return Ok(consultaUrl);


        }
    }
}