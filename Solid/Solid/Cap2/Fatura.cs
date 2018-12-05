using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap2
{
    class Fatura
    {
        public double ValorMensal { get; private set; }
        public string Nome { get; private set; }

        public Fatura(double valorMensal, string nome)
        {
            this.ValorMensal = valorMensal;
            this.Nome = nome;
        }


    }
}
