using API2.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Services
{
    public class JurosService : IJurosService
    {
        private readonly UrlsConfigurations _urlsConfigurations;
        public JurosService(IOptions<UrlsConfigurations> urlsConfigurations)
        {
            _urlsConfigurations = urlsConfigurations.Value;
        }

        public double CalculaJuros(double valor, double juros, int tempo)
        {
            return valor * Math.Pow((1 + juros), tempo);
        }

        public double GetJuros()
        {
            using (var httpClient = new HttpClient())
            {
                var data = httpClient.GetAsync($"{_urlsConfigurations.API1}/juros/taxaJuros").Result;
                if (data.StatusCode == HttpStatusCode.OK)
                {
                    return double.Parse(data.Content.ReadAsStringAsync().Result);
                }
            }
            return 0;
        }

        public string ShowMeTheCode()
        {
            return "Teste";
        }
    }
}
