using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class AvaliadorTest
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [SetUp]
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();

            this.joao = new Usuario("Joao");
            this.jose = new Usuario("Jose");
            this.maria = new Usuario("Maria");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescenteTest()
        {
            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(maria, 250));
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(jose, 400));

            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescenteTest()
        {
            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(jose, 400));
            leilao.Propoe(new Lance(joao, 300));
            leilao.Propoe(new Lance(maria, 200));
            leilao.Propoe(new Lance(joao, 100));

            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 100;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmQualquerOrdemTest()
        {
            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(maria, 200));
            leilao.Propoe(new Lance(joao, 450));
            leilao.Propoe(new Lance(jose, 120));
            leilao.Propoe(new Lance(maria, 700));
            leilao.Propoe(new Lance(joao, 630));
            leilao.Propoe(new Lance(jose, 230));

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(120, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void MediaDosLancesTest()
        {
            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(maria, 300));
            leilao.Propoe(new Lance(joao, 400));
            leilao.Propoe(new Lance(jose, 500));

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400, leiloeiro.Media, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLanceTest()
        {
            Leilao leilao = new CriadorDeLeilao().Para("PS3 Novo")
                .Lance(joao, 1000).Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLancesTest()
        {
            Leilao leilao = new CriadorDeLeilao().Para("PS 3 Novo")
                .Lance(joao, 100)
                .Lance(maria, 200)
                .Lance(joao, 300)
                .Lance(maria, 400)
                .Constroi();

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsDoisLancesTest()
        {
            Leilao leilao = new Leilao("PS 3 Novo");

            leilao.Propoe(new Lance(joao, 100));
            leilao.Propoe(new Lance(maria, 400));

            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(100, maiores[1].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAvaliarLeiloesSemNenhumLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("PS3").Constroi();

            Assert.Throws<Exception>(() => leiloeiro.Avalia(leilao));
        }

        [TearDown]
        public void Finaliza()
        {
            Debug.WriteLine("fim");
            Console.WriteLine("fim");
        }
    }
}
