using DesignPatterns2.Cap2;
using DesignPatterns2.Cap3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DesignPatterns2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Factory();
            Flyweight();
            Memento();

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
    }
}
