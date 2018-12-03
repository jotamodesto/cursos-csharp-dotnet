using DesignPatterns2.Cap2;
using DesignPatterns2.Cap3;
using DesignPatterns2.Cap4;
using DesignPatterns2.Cap5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Factory();
            Flyweight();
            Memento();
            Interpreter();
            Visitor();

            Console.ReadKey();
        }

        static void Factory()
        {
            Console.WriteLine("Factory");

            IDbConnection conexao = new ConnectionFactory().GetConnection();

            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tabela";

            Console.WriteLine("-------------");
        }

        static void Flyweight()
        {
            Console.WriteLine("Flyweight");

            NotasMusicais notas = new NotasMusicais();

            IList<INota> musica = new List<INota>()
            {
                notas.Pega("do"),
                notas.Pega("re"),
                notas.Pega("mi"),
                notas.Pega("fa"),
                notas.Pega("fa"),
                notas.Pega("fa")
            };

            Piano piano = new Piano();
            piano.Toca(musica);

            Console.WriteLine("-------------");
        }

        static void Memento()
        {
            Console.WriteLine("Memento");

            Historico historico = new Historico();

            Contrato c = new Contrato(DateTime.Now, "Johnatan", TipoContrato.Novo);
            historico.Adiciona(c.SalvaEstado());

            c.Avanca();
            historico.Adiciona(c.SalvaEstado());

            c.Avanca();
            historico.Adiciona(c.SalvaEstado());

            Console.WriteLine(historico.Pega(2).Contrato.Tipo);

            Console.WriteLine("-------------");
        }

        static void Interpreter()
        {
            Console.WriteLine("Interpreter");

            var esquerda = new Soma(new Numero(1), new Numero(10));
            var direita = new Subtracao(new Numero(20), new Numero(10));
            var soma = new Soma(esquerda, direita);

            Console.WriteLine(soma.Avalia());

            // Usando Expressions
            Expression somaEx = Expression.Add(Expression.Constant(10), Expression.Constant(100));
            Func<int> funcao = Expression.Lambda<Func<int>>(somaEx).Compile();

            Console.WriteLine(funcao());

            Console.WriteLine("-------------");
        }

        static void Visitor()
        {
            Console.WriteLine("Visitor");

            var esquerda = new Soma(new Numero(1), new Numero(10));
            var direita = new Subtracao(new Numero(20), new Numero(10));
            var soma = new Soma(esquerda, direita);

            ImpressoraVisitor impressora = new ImpressoraVisitor();

            soma.Aceita(impressora);
            Console.Write("=");
            Console.Write(soma.Avalia());

            Console.WriteLine("\n-------------");
        }
    }
}
