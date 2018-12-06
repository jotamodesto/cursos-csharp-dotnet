using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class ManipuladorDeSaldo
    {
        public double Saldo { get; private set; }

        public void Deposita(double valor)
        {
            Saldo += valor;
        }

        public void Saca(double valor)
        {
            if (valor <= Saldo)
            {
                Saldo -= valor;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void SomaInvestimento(double taxa)
        {
            Saldo *= taxa;
        }
    }
}
