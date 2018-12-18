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
        public List<Lance> TresMaiores { get; private set; }

        public double Media { get; private set; } = 0;

        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
                throw new Exception("Não é possível avaliar um leilão sem lances");

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

            PegaOsMaioresNo(leilao);

            Media = leilao.Lances.Count > 0 ? leilao.Lances.Average(l => l.Valor) : 0;
        }

        private void PegaOsMaioresNo(Leilao leilao)
        {
            TresMaiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            TresMaiores = TresMaiores.GetRange(0, TresMaiores.Count >= 3 ? 3 : TresMaiores.Count);
        }
    }
}
