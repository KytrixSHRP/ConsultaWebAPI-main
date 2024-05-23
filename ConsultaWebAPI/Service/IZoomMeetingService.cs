using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;

namespace ConsultaWebAPI.Service
{
    public interface IZoomMeetingService
    {
        public Task<string> GerarConsultaZoom(Agendamento agendamento, string token);
    }
}