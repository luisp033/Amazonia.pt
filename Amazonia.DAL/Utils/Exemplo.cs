using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Utils
{
    public static class Exemplo
    {
        public static string ObterValorDoConfig(string chave)
        {
            var valorDaChave = ConfigurationManager.AppSettings[chave];
            return valorDaChave;
        }


        public static T ObterValorDoConfig<T>(string chave)
        {
            try
            {
                var valorDaChave = ConfigurationManager.AppSettings[chave];

                var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    return (T)converter.ConvertFromString(valorDaChave);
                }
                return default(T);
            }
            catch (ArgumentException)
            {
                return default(T);
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }



        public static T MyObterValorDoConfig<T>(string chave)
        {
            var valorDaChave = ConfigurationManager.AppSettings[chave];

            T result = default(T);

            if (typeof(T) == typeof(int?))
            {
                int valor;
                bool importacaoOk = Int32.TryParse(valorDaChave, out valor);
                if (importacaoOk) 
                {
                    result = (T)Convert.ChangeType(valor, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
                }
            }
            else if (typeof(T) == typeof(decimal?))
            {
                decimal valor;
                bool importacaoOk = Decimal.TryParse(valorDaChave, out valor);
                if (importacaoOk) 
                {
                    result = (T)Convert.ChangeType(valor, Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T));
                }
            }

            //return (T)Convert.ChangeType(result, default(T).GetType());
            return result;
        }




    }
}
