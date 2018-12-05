using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap4
{
    class ProcessadorDeBoletos
    {
        public void Processa(IList<Boleto> boletos, Fatura fatura)
        {
            foreach (var boleto in boletos)
            {
                Pagamento pagamento = new Pagamento(boleto.Valor, MeioDePagamento.BOLETO);
                fatura.AdicionaPagamento(pagamento);
            }
        }
    }
}
