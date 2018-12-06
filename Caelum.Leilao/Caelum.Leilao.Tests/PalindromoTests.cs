using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class PalindromoTests
    {
        [Test]
        public void EhPalindromoTest()
        {
            Palindromo palindromo = new Palindromo();

            string fraseTeste = "Socorram-me subi no onibus em Marrocos";

            Assert.IsTrue(palindromo.EhPalindromo(fraseTeste));
        }

        [Test]
        public void NaoEhPalindromoTest()
        {
            Palindromo palindromo = new Palindromo();

            string fraseTeste = "isso nao eh palindromo";

            Assert.IsFalse(palindromo.EhPalindromo(fraseTeste));
        }
    }
}
