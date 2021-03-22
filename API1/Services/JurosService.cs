using API1.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Services
{
    public class JurosService : IJurosService
    {
        private readonly JurosConfigurations _jurosConfigurations;
        public JurosService(IOptions<JurosConfigurations> jurosConfigurations)
        {
            _jurosConfigurations = jurosConfigurations.Value;
        }

        public double CalcularJuros()
        {
            return _jurosConfigurations.Taxa;
        }
    }
}
