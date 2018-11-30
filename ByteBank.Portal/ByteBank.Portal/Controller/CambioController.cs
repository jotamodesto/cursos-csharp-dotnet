﻿using ByteBank.Portal.Filtros;
using ByteBank.Portal.Infraestrutura;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;
        private ICartaoService _cartaoService;

        public CambioController(ICambioService cambioServico, ICartaoService cartaoServico)
        {
            _cambioService = cambioServico;
            _cartaoService = cartaoServico;
        }

        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);
            var textoPagina = View();

            return View(new
            {
                ValorEmReais = valorFinal
            });
        }

        [ApenasHorarioComercialFiltro]
        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 4);
            var textoPagina = View();

            return View(new
            {
                ValorEmReais = valorFinal
            });
        }

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = _cartaoService.ObterCartaoDeCreditoDeDestaque();

            var modelo = new
            {
                MoedaDestino = moedaDestino,
                ValorDestino = valorFinal,
                MoedaOrigem = moedaOrigem,
                ValorOrigem = valor,
                CartaoPromocao = cartaoPromocao
            };

            return View(modelo);
        }

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor) 
            => Calculo("BRL", moedaDestino, valor);

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino) 
            => Calculo("BRL", moedaDestino, 1);
    }
}
