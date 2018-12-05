using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    class CalculadoraDeSalario
    {
        public double Calcula(Funcionario funcionario)
        {
            return funcionario.CalculaSalario();
        }
    }
}
