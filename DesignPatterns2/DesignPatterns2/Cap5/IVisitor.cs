using DesignPatterns2.Cap4;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap5
{
    interface IVisitor
    {
        void ImprimeSoma(Soma soma);
        void ImprimeSubtracao(Subtracao subtracao);
        void ImprimeNumero(Numero numero);
    }
}
