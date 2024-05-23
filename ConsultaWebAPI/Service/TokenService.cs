using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsultaWebAPI.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace ConsultaWebAPI.Service
{
    public class TokenService : ITokenService
    {
        public async Task<Token> GetToken()
        {
            var accountId = "2vIbaSdsTDuc2KwYHs4cGg";
            var authString = $"ho0LlK12Rpary6rHUMfV4w:Fp05ubjfFIgHcwKNGQt2J0p51S1728ZZ";
            var base64Auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(authString));
            var queryString = new Dictionary<string, string>(){["grant_type"] = "account_credentials", ["account_id"] = $"{accountId}"};
            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.zoom.us/oauth/token")
            };

            httpClient.DefaultRequestHeaders.Add($"Authorization", $"Basic {base64Auth}");
            
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(QueryHelpers.AddQueryString(httpClient.BaseAddress.ToString(), queryString), null).ConfigureAwait(false);
            // For Get Method
            // For Post Method
            var content  = await httpResponseMessage.Content.ReadAsStringAsync();
            var token =  JsonSerializer.Deserialize<Token>(content);
            return token;
        }
    }
}