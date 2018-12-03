using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns2.Cap4;

namespace DesignPatterns2.Cap5
{
    class ExpressaoVisitor : IVisitor
    {
        public void ImprimeNumero(Numero numero)
        {
            Console.Write(numero.Valor + " ");
        }

        public void ImprimeSoma(Soma soma)
        {
            Console.Write("( ");
            Console.Write("+ ");
            soma.Esquerda.Aceita(this);
            soma.Direita.Aceita(this);
            Console.Write(" )");
        }

        public void ImprimeSubtracao(Subtracao subtracao)
        {
            Console.Write("( ");
            Console.Write("- ");
            subtracao.Esquerda.Aceita(this);
            subtracao.Direita.Aceita(this);
            Console.Write(" )");
        }
    }
}
