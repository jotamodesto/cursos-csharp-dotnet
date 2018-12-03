using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap3
{
    class Historico
    {
        private IList<Estado> Estados = new List<Estado>();

        public void Adiciona(Estado estado)
        {
            this.Estados.Add(estado);
        }

        public Estado Pega(int indice)
        {
            return this.Estados[indice];
        }
    }
}
