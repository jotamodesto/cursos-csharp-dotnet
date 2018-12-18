using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class LanceTests
    {
        private Usuario usuario;

        [SetUp]
        public void CriaTeste()
        {
            usuario = new Usuario("Usuario");
        }

        [Test]
        public void LanceNaoPodeSerZeroTest()
        {
            Assert.Throws<Exception>(() => new Lance(usuario, 0));
        }

        [Test]
        public void LanceNaoPodeSerNegativoTest()
        {
            Assert.Throws<Exception>(() => new Lance(usuario, -1));
        }
    }
}
