using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap6
{
    class EnviaPorSms : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por SMS");
            Console.WriteLine(mensagem.Formata());
        }
    }
}
