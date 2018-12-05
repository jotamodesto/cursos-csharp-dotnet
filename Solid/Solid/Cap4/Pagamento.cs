using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap4
{
    class Pagamento
    {
        public double Valor { get; internal set; }
        private MeioDePagamento bOLETO;

        public Pagamento(double valor, MeioDePagamento meioDePagamento)
        {
            this.Valor = valor;
            this.bOLETO = meioDePagamento;
        }
    }
}
