using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap6
{
    class MensagemCliente : IMensagem
    {
        private readonly string nome;
        public IEnviador Enviador { get; set; }

        public MensagemCliente(string nome)
        {
            this.nome = nome;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string Formata()
        {
            return string.Format("Mensagem para o cliente {0}", nome);
        }
    }
}
