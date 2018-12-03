using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap6
{
    class MensagemAdministrativa : IMensagem
    {
        private readonly string nome;
        public IEnviador Enviador { get; set; }

        public MensagemAdministrativa(string nome)
        {
            this.nome = nome;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string Formata()
        {
            return string.Format("Enviando a mensagem para o admnistrador {0}", nome);
        }
    }
}
