using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        [Test]
        public void DeveEntenderLancesEmOrdemCrescenteTest()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(maria, 250));
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void MediaDosLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(maria, 300));
            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(jose, 500));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.Media, 0.0001);
        }
    }
}
