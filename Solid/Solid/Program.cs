﻿using Solid.Cap2;
using Solid.Cap3;
using Solid.Cap4;
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
            DependencyInversion();
            Encapsuling();

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
            Cap2.Fatura fatura = new Cap2.Fatura(2000, "Johnatan");
            gnf.Gera(fatura);

            Console.WriteLine("------------------------");
        }

        static void DependencyInversion()
        {
            Console.WriteLine("Dependency Inversion");

            Compra compra = new Compra(500, "sao paulo");
            CalculadoraDePrecos calc = new CalculadoraDePrecos(new TabelaDePrecoPadrao(), new Transportadora());

            double resultado = calc.Calcula(compra);

            Console.WriteLine("O preço da compra é: " + resultado);

            Console.WriteLine("------------------------");
        }

        static void Encapsuling()
        {
            Console.WriteLine("Encapsuling");

            Cap4.Fatura fatura = new Cap4.Fatura("john", 1000);
            ProcessadorDeBoletos processador = new ProcessadorDeBoletos();
            var boletos = new List<Boleto>() { new Boleto() { Valor = 1000 } };

            processador.Processa(boletos, fatura);

            Console.WriteLine(fatura.Pago);

            Console.WriteLine("------------------------");
        }
    }
}
