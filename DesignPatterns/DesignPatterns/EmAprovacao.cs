using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class EmAprovacao : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento) => orcamento.Valor = orcamento.Valor - (orcamento.Valor * 0.05);

        public void Aprova(Orcamento orcamento) => orcamento.EstadoAtual = new Aprovado();

        public void Reprova(Orcamento orcamento) => orcamento.EstadoAtual = new Reprovado();

        public void Finaliza(Orcamento orcamento) => throw new Exception("Orçcamento em aprovação não pode ir direto para finalizado");
    }
}