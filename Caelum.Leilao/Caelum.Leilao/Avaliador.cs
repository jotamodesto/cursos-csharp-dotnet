using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        public double MaiorLance { get; private set; } = double.MinValue;
        public double MenorLance { get; private set; } = double.MaxValue;
        public double Media { get; private set; } = 0;

        public void Avalia(Leilao leilao)
        {
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > MaiorLance)
                {
                    MaiorLance = lance.Valor;
                }
                if (lance.Valor < MenorLance)
                {
                    MenorLance = lance.Valor;
                }
            }

            Media = leilao.Lances.Average(l => l.Valor);
        }
    }
}
