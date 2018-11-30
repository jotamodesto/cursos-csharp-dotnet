using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class ICMS : Imposto
    {
        public ICMS() : base()
        { }

        public ICMS(Imposto outroImposto) : base(outroImposto)
        { }
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculoDoOutroImposto(orcamento);
        }
    }
}
