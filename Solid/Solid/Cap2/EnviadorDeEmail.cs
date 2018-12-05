using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap2
{
    class EnviadorDeEmail : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Enviando nota por e-mail");
        }
    }
}
