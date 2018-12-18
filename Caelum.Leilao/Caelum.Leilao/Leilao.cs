using System;
using System.Collections.Generic;
using System.Linq;
namespace Caelum.Leilao
{
    public class Leilao
    {
        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            int total = QtdDeLancesDo(lance.Usuario);

            if (PodeDarLance(lance.Usuario))
            {
                Lances.Add(lance);
            }
        }

        public void DobraLance(Usuario usuario)
        {
            var ultimoLance = this.Lances.Last(l => l.Usuario.Equals(usuario));

            this.Propoe(new Lance(usuario, ultimoLance.Valor * 2));
        }

        private bool PodeDarLance(Usuario usuario)
        {
            return Lances.Count == 0 || (!UltimoLanceDado().Usuario.Equals(usuario) &&
                            QtdDeLancesDo(usuario) < 5);
        }

        private int QtdDeLancesDo(Usuario usuario)
        {
            int total = 0;
            foreach (var l in Lances)
            {
                if (l.Usuario.Equals(usuario)) total++;
            }

            return total;
        }

        private Lance UltimoLanceDado()
        {
            return Lances[Lances.Count - 1];
        }
    }
}