using Solid.Cap2;
using System;
using System.Collections.Generic;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleResponsibility();
            Decoupling();

            Console.ReadKey();
        }

        static void SingleResponsibility()
        {
            Console.WriteLine("SingleResponsibility");

            CalculadoraDeSalario cs = new CalculadoraDeSalario();
            Funcionario funcionario = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);
            double resultado;

            resultado = cs.Calcula(funcionario);

            Console.WriteLine("O salário de um desenvolvedor que ganha 2000 bruto é: " + resultado);

            Console.WriteLine("------------------------");
        }

        static void Decoupling()
        {
            Console.WriteLine("Decoupling");

            IList<IAcaoAposGerarNota> acoes = new List<IAcaoAposGerarNota>();
            acoes.Add(new EnviadorDeEmail());
            acoes.Add(new NotaFiscalDao());
            GeradorDeNotaFiscal gnf = new GeradorDeNotaFiscal(acoes);
            Fatura fatura = new Fatura(2000, "Johnatan");
            gnf.Gera(fatura);

            Console.WriteLine("------------------------");
        }

        static void DependencyInversion()
        {
            Console.WriteLine("Dependency Inversion");

            Console.WriteLine("------------------------");
        }
    }
}
