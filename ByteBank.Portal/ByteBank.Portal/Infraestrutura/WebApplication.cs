using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Portal.Controller;
using ByteBank.Portal.Infraestrutura;
using ByteBank.Portal.Infraestrutura.IoC;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        private readonly string[] _prefixos;
        private readonly IContainer _container = new ContainerSimples();

        public WebApplication(params string[] prefixos)
        {
            if (prefixos == null)
                throw new ArgumentException(nameof(prefixos));

            _prefixos = prefixos;

            Configurar();
        }

        private void Configurar()
        {
            //_container.Registrar(typeof(ICambioService), typeof(CambioTesteService));
            //_container.Registrar(typeof(ICartaoService), typeof(CartaoServiceTeste));

            _container.Registrar<ICambioService, CambioTesteService>();
            _container.Registrar<ICartaoService, CartaoServiceTeste>();
        }

        public void Iniciar()
        {
            while (true)
                ManipularRequisicao();
        }

        private void ManipularRequisicao()
        {
            var httpListerner = new HttpListener();

            foreach (var prefixo in _prefixos)
            {
                httpListerner.Prefixes.Add(prefixo);
            }

            httpListerner.Start();

            var contexto = httpListerner.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.PathAndQuery;

            if (path.EhArquivo())
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }

            httpListerner.Stop();
        }
    }
}
