using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap2
{
    class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }
}
