using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Cap5
{
    class ContaEstudante : ContaComum
    {
        private ManipuladorDeSaldo m;
        public int Milhas { get; private set; }

        public ContaEstudante()
        {
            m = new ManipuladorDeSaldo();
        }

        public new void Deposita(double valor)
        {
            base.Deposita(valor);
            Milhas += (int)valor;
        }
    }
}
