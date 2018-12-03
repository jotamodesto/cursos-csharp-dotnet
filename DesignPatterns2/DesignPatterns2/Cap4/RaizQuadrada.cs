using DesignPatterns2.Cap5;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap4
{
    struct RaizQuadrada : IExpressao
    {
        private IExpressao numero;

        public RaizQuadrada(IExpressao numero)
        {
            this.numero = numero;
        }

        public int Avalia()
        {
            int valor = numero.Avalia();
            return (int)Math.Sqrt(valor);
        }

        public void Aceita(IVisitor impressora)
        {
            //impressora.ImprimeSubstracao(this);
        }
    }
}
