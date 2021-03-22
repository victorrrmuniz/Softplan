using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Services
{
    public interface IJurosService
    {
        public double CalculaJuros(double valor, double juros, int tempo);
        public double GetJuros();
        public string ShowMeTheCode();
    }
}
