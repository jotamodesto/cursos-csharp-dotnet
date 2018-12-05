using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap3
{
    class Compra
    {
        public double Valor { get; set; }
        public string Cidade { get; private set; }

        public Compra(double valor, string cidade)
        {
            this.Valor = valor;
            this.Cidade = cidade;
        }
    }
}
