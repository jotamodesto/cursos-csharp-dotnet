using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    abstract class Cargo
    {
        public IRegraDeCalculo Regra { get; private set; }

        public Cargo(IRegraDeCalculo regra)
        {
            Regra = regra;
        }
    }
}
