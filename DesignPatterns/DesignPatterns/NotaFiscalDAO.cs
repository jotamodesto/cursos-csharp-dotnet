using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class NotaFiscalDAO : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Salvando no BD");
        }
    }
}
