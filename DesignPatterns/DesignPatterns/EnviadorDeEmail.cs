using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando por e-mail");
        }
    }
}
