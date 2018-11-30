using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class EnviadorDeSms : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando por sms");
        }
    }
}
