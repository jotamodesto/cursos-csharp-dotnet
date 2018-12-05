using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap4
{
    class Fatura
    {
        private IList<Pagamento> pagamentos;

        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public bool Pago { get; set; }

        public Fatura(string cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            pagamentos = new List<Pagamento>();
            Pago = false;
        }

        public void AdicionaPagamento(Pagamento pagamento)
        {
            pagamentos.Add(pagamento);

            if (valorTotalDosPagamentos() >= Valor)
            {
                Pago = true;
            }
        }

        private double valorTotalDosPagamentos()
        {
            double total = 0;

            foreach (var pagamento in pagamentos)
            {
                total += pagamento.Valor;
            }

            return total;
        }
    }
}
