using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap2
{
    class NotaFiscal
    {
        private double valor;
        private double imposto;

        public NotaFiscal(double valor, double imposto)
        {
            this.valor = valor;
            this.imposto = imposto;
        }
    }
}
