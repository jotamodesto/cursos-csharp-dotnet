using DesignPatterns2.Cap2;
using DesignPatterns2.Cap3;
using DesignPatterns2.Cap4;
using DesignPatterns2.Cap5;
using DesignPatterns2.Cap6;
using DesignPatterns2.Cap7;
using DesignPatterns2.Cap8;
using DesignPatterns2.Cap9;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Serialization;

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
            Bridge();
            Command();
            Adapter();

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

        static void Bridge()
        {
            Console.WriteLine("Bridge");

            IMensagem mensagem = new MensagemCliente("Johnatan");
            IEnviador enviadorSms = new EnviaPorSms();
            mensagem.Enviador = enviadorSms;
            mensagem.Envia();

            IMensagem mensagemAdm = new MensagemAdministrativa("Johnatan");
            IEnviador enviadorEmail = new EnviaPorEmail();
            mensagemAdm.Enviador = enviadorEmail;
            mensagemAdm.Envia();


            Console.WriteLine("-------------");
        }

        static void Command()
        {
            Console.WriteLine("Command");

            FilaDeTrabalho fila = new FilaDeTrabalho();
            Pedido pedido1 = new Pedido("Johnatan", 100);
            Pedido pedido2 = new Pedido("Jow", 200);

            fila.Adiciona(new PagaPedido(pedido1));
            fila.Adiciona(new PagaPedido(pedido2));

            fila.Adiciona(new FinalizaPedido(pedido1));

            fila.Processa();

            Console.WriteLine("-------------");
        }

        static void Adapter()
        {
            Console.WriteLine("Adapter");

            Cliente cliente = new Cliente();
            cliente.Nome = "Johnatan";
            cliente.Endereco = "Rua da Mooca";
            cliente.DataNascimento = DateTime.Now;

            string xml = new GeradorDeXml().GeraXml(cliente);

            Console.WriteLine(xml);

            Console.WriteLine("-------------");
        }

        static void SingletonFacade()
        {
            Console.WriteLine("Singleton & Façades");

            string cpf = "1234";

            EmpresaFacade facade = EmpresaFacadeSingleton.Instancia;

            var cliente = facade.BuscaCliente(cpf);
            var fatura = facade.CriaFatura(cliente, 5000);
            facade.GeraCobranca(tipo.Boleto, fatura);

            Console.WriteLine("-------------");
        }
    }
}
