using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;

namespace ConsultaWebAPI.Service
{
    public class ZoomMeetingService : IZoomMeetingService
    {
        public async Task<string> GerarConsultaZoom(Agendamento agendamento, string token)
        {

            var obj = new {
                topic = "Medium Test Meeting",
                type =  2, //2 - Scheduled Meeting
                start_time= agendamento.DataAgendamento, //yyy-MM-dd'T'HH:mm:ss
                duration =  30,
                timezone= "UTC",
                agenda="Test Agenda",
                settings = new {
                    meeting_invitees = new List<object>(){ new{
                        email = agendamento.EmailPaciente
                    }},
                    join_before_host = true
                }
            };
            
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.zoom.us/v2/users/me/meetings")
            };

            httpClient.DefaultRequestHeaders.Add($"Authorization", $"Bearer {token}");
            var json = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(httpClient.BaseAddress, stringContent);

            var content  = await httpResponseMessage.Content.ReadAsStringAsync();

            var meeting = JsonSerializer.Deserialize<MeetingUrl>(content);

            return meeting.ConsultaUrl;
        }
    }
}