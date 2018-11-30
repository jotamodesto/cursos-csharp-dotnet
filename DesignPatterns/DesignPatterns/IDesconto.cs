using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public interface IDesconto
    {
        double Desconta(Orcamento orcamento);
        IDesconto Proximo { get; set; }
    }
}
