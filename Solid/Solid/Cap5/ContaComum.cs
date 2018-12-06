using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap5
{
    class ContaComum
    {
        private ManipuladorDeSaldo manipulador;

        public double Saldo { get => manipulador.Saldo; }

        public ContaComum()
        {
            manipulador = new ManipuladorDeSaldo();
        }

        public void Deposita(double valor)
        {
            manipulador.Deposita(valor);
        }

        public void Saca(double valor)
        {
            manipulador.Saca(valor);
        }

        public void SomaInvestimento()
        {
            manipulador.SomaInvestimento(1.1);
        }
    }
}
