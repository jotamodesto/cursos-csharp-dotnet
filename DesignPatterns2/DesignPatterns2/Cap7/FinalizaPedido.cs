using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap7
{
    class FinalizaPedido : IComando
    {
        private readonly Pedido pedido;

        public FinalizaPedido(Pedido pedido)
        {
            this.pedido = pedido;
        }

        public void Executa()
        {
            Console.WriteLine("Finalizando o Pedido do cliente {0}", pedido.Cliente);
            pedido.Finaliza();
        }
    }
}
