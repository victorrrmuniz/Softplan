using API1.Configurations;
using API1.Services;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace API1Tests
{
    public class Tests
    {
        private readonly IOptions<JurosConfigurations> _jurosConfigurations;
        private readonly JurosService _jurosService;
        public Tests()
        {
            _jurosConfigurations = Options.Create<JurosConfigurations>(new JurosConfigurations());
            _jurosConfigurations.Value.Taxa = 0.01;
            _jurosService = new JurosService(_jurosConfigurations);
        }
        
        [Test]
        public void VeirificarTaxaDeJuros()
        {
            var result = _jurosService.CalcularJuros();
            Assert.AreEqual(result, 0.01);
        }
    }
}