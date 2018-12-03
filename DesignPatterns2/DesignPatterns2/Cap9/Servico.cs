using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap9
{
    class Servico
    {
        private static Servico servico;
        public static Servico Instancia
        {
            get
            {
                if (servico == null)
                    servico = new Servico();

                return servico;
            }
        }

        private Servico()
        {

        }
    }
}
