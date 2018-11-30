using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.Binding
{
    public class ActionBindingInfo
    {
        public MethodInfo MethodInfo { get; private set; }
        public IReadOnlyCollection<ArgumentoNomeValor> TuplasAgrumentoNomeValor { get; private set; }

        public ActionBindingInfo(MethodInfo methodInfo, IEnumerable<ArgumentoNomeValor> tuplasArgumentoNomeValor)
        {
            MethodInfo = methodInfo ?? throw new ArgumentNullException(nameof(MethodInfo));

            if (tuplasArgumentoNomeValor == null)
                throw new ArgumentNullException(nameof(TuplasAgrumentoNomeValor));

            TuplasAgrumentoNomeValor = new ReadOnlyCollection<ArgumentoNomeValor>(tuplasArgumentoNomeValor.ToList());
        }

        public object Invoke(object controller)
        {
            var countParametros = TuplasAgrumentoNomeValor.Count;
            var possuiArgumentos = countParametros > 0;

            if (!possuiArgumentos)
                return MethodInfo.Invoke(controller, new object[0]);
            else
            {
                var parametrosInvoke = new object[countParametros];
                var parametrosMethodInfo = MethodInfo.GetParameters();

                for (int i = 0; i < countParametros; i++)
                {
                    var parametro = parametrosMethodInfo[i];
                    var parametroNome = parametro.Name;

                    var argumento = TuplasAgrumentoNomeValor.Single(t => t.Nome == parametroNome);

                    parametrosInvoke[i] = Convert.ChangeType(argumento.Valor, parametro.ParameterType);
                }

                return MethodInfo.Invoke(controller, parametrosInvoke);
            }
        }
    }
}
