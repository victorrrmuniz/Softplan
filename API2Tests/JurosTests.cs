using API2.Configurations;
using API2.Services;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace API2Tests
{
    public class Tests
    {
        private readonly IOptions<UrlsConfigurations> _urlsConfigurations;
        private readonly JurosService _jurosService;


        public Tests()
        {
            _urlsConfigurations = Options.Create<UrlsConfigurations>(new UrlsConfigurations());
            _urlsConfigurations.Value.API1 = "https://localhost:44324";
            _urlsConfigurations.Value.GitHub = "https://github.com/victorrrmuniz/Softplan";
            _jurosService = new JurosService(_urlsConfigurations);
        }
        

        [Test]
        public void VerificarCalcularDeJuros()
        {
            double valor = 100;
            double juros = 0.01;
            int tempo = 2;
            var result = _jurosService.CalculaJuros(valor, juros, tempo);
            Assert.AreEqual(result, 102.01);
        }

        [Test]
        public void RetornarURLdoGitHub()
        {
            
            var result = _jurosService.ShowMeTheCode();
            Assert.AreEqual(result, "https://github.com/victorrrmuniz/Softplan");
        }
    }
}