using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class LeilaoTests
    {
        [Test]
        public void DeveReceberUmLanceTest()
        {
            Leilao leilao = new Leilao("MacBook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            var usuario = new Usuario("Steve Jobs");
            leilao.Propoe(new Lance(usuario, 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void DeveReceberVariosLancesTest()
        {
            Leilao leilao = new Leilao("Macbook");
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniac"), 3000));

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuarioTest()
        {
            Leilao leilao = new Leilao("Macbook");
            var steveJobs = new Usuario("Steve Jobs");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.0001);
        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDoMesmoUsuario()
        {
            Leilao leilao = new Leilao("Macbook");
            var steveJobs = new Usuario("Steve Jobs");
            var billGates = new Usuario("Bill Gates");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));
            leilao.Propoe(new Lance(steveJobs, 4000));
            leilao.Propoe(new Lance(billGates, 5000));
            leilao.Propoe(new Lance(steveJobs, 6000));
            leilao.Propoe(new Lance(billGates, 7000));
            leilao.Propoe(new Lance(steveJobs, 8000));
            leilao.Propoe(new Lance(billGates, 9000));
            leilao.Propoe(new Lance(steveJobs, 10000));
            leilao.Propoe(new Lance(billGates, 11000));

            //Deve ser ignorado
            leilao.Propoe(new Lance(steveJobs, 12000));

            Assert.AreEqual(10, leilao.Lances.Count);
            Lance ultimoLance = leilao.Lances[leilao.Lances.Count - 1];

            Assert.AreEqual(11000, ultimoLance.Valor, 0.00001);

        }

        [Test]
        public void DobraLanceTest()
        {
            Leilao leilao = new Leilao("Macbook");
            var steveJobs = new Usuario("Steve Jobs");
            var billGates = new Usuario("Bill Gates");

            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(billGates, 3000));
            leilao.DobraLance(steveJobs);

            Assert.AreEqual(3, leilao.Lances.Count);
            Assert.AreEqual(4000, leilao.Lances[2].Valor, 0.00001);
        }
    }
}
