using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap6
{
    interface IEnviador
    {
        void Envia(IMensagem mensagem);
    }
}
