using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class Funcionario
    {
        public Cargo Cargo { get; private set; }
        public double SalarioBase { get; private set; }

        public Funcionario(Cargo cargo, double salarioBase)
        {
            Cargo = cargo;
            SalarioBase = salarioBase;
        }

        public double CalculaSalario()
        {
            return Cargo.Regra.Calcula(this);
        }
    }
}
