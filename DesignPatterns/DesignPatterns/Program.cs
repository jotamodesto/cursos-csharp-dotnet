using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Strategy();
            ChainOfResponsibility();
            TemplateMethod();
            Decorator();
            State();
            Builder();
            Observer();

            Console.ReadKey();
        }

        private static void Strategy()
        {
            Console.WriteLine("Strategy");

            Imposto iss = new ISS();
            Imposto icms = new ICMS();

            Orcamento orcamento = new Orcamento(500.0);

            CalculadorDeImpostos calculador = new CalculadorDeImpostos();
            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, icms);

            Console.WriteLine("---------------");
        }

        private static void ChainOfResponsibility()
        {
            Console.WriteLine("Chain of Responsibility");

            CalculadorDeDescontos calculador = new CalculadorDeDescontos();
            Orcamento orcamento = new Orcamento(501.0);

            orcamento.AdicionaItem(new Item("CANETA", 250));
            orcamento.AdicionaItem(new Item("LAPIS", 250));
            orcamento.AdicionaItem(new Item("GELADEIRA", 250));
            orcamento.AdicionaItem(new Item("FOGÃO", 250));
            orcamento.AdicionaItem(new Item("MICROONDAS", 250));
            //orcamento.AdicionaItem(new Item("XBOX", 250));

            double desconto = calculador.Calcula(orcamento);
            Console.WriteLine(desconto);

            Console.WriteLine("---------------");
        }

        private static void TemplateMethod()
        {
            Console.WriteLine("Template Method");



            Console.WriteLine("---------------");
        }

        private static void Decorator()
        {
            Console.WriteLine("Decorator");

            Imposto iss = new ISS(new ICMS());
            Orcamento orcamento = new Orcamento(500);

            double valor = iss.Calcula(orcamento);

            Console.WriteLine(valor);

            Console.WriteLine("---------------");
        }

        private static void State()
        {
            Console.WriteLine("State");

            Orcamento reforma = new Orcamento(500);

            Console.WriteLine(reforma.Valor);

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Aprova();
            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);

            reforma.Finaliza();

            Console.WriteLine("---------------");
        }

        private static void Builder()
        {
            Console.WriteLine("Builder");

            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            criador
                .ParaEmpresa("Caelum Ensino e Inovação")
                .ComCnpj("23.456.789/0001/12")
                .ComItem(new ItemDaNota("Item 1", 100))
                .ComItem(new ItemDaNota("Item 2", 200))
                .NaDataAtual()
                .ComObservacoes("Uma obs qualquer");

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);

            Console.WriteLine("---------------");
        }

        private static void Observer()
        {
            Console.WriteLine("Observer");

            NotaFiscalBuilder criador = new NotaFiscalBuilder();
            criador
                .ParaEmpresa("Caelum Ensino e Inovação")
                .ComCnpj("23.456.789/0001/12")
                .ComItem(new ItemDaNota("Item 1", 100))
                .ComItem(new ItemDaNota("Item 2", 200))
                .NaDataAtual()
                .ComObservacoes("Uma obs qualquer");

            criador.AdicionaAcao(new EnviadorDeEmail());
            criador.AdicionaAcao(new NotaFiscalDAO());
            criador.AdicionaAcao(new EnviadorDeSms());

            NotaFiscal nf = criador.Constroi();

            Console.WriteLine(nf.ValorBruto);
            Console.WriteLine(nf.Impostos);

            Console.WriteLine("---------------");
        }
    }
}
