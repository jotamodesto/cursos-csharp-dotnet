using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class Aprovado : IEstadoDeUmOrcamento
    {
        public void AplicaDescontoExtra(Orcamento orcamento) => orcamento.Valor -= orcamento.Valor * 0.02;

        public void Aprova(Orcamento orcamento) => throw new Exception("Orçamento já está em estado de aprovação");

        public void Finaliza(Orcamento orcamento) => orcamento.EstadoAtual = new Finalizado();

        public void Reprova(Orcamento orcamento) => throw new Exception("Orçamento está em aprovado, não pode ser reprovado.");
    }
}
