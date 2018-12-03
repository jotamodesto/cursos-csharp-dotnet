using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap7
{
    class PagaPedido : IComando
    {
        private readonly Pedido pedido;

        public PagaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }

        public void Executa()
        {
            Console.WriteLine("Pagando o Pedido do cliente {0}", pedido.Cliente);
            pedido.Paga();
        }
    }
}
