using DesignPatterns2.Cap5;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns2.Cap4
{
    interface IExpressao
    {
        int Avalia();

        void Aceita(IVisitor impressora);
    }
}
