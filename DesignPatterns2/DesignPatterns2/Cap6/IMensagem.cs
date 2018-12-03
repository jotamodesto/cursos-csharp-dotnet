using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap6
{
    interface IMensagem
    {
        IEnviador Enviador { get; set; }

        void Envia();

        string Formata();
    }
}
