using Amazonia.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class LivroPeriodico : Livro
    {
        public DateTime DataLancamento { get; set; }

        public LivroPeriodico()
        {
            if (DataLancamento == new DateTime()) 
            {
                DataLancamento = DateTime.Today;
            }
        }


        public override decimal ObterPreco()
        {

            var descontoAPartirdeDias = Exemplo.ObterValorDoConfig<int?>("revistaPeriodicaDescontoAPartirdeDias");


            var descontoPercentagem = Exemplo.ObterValorDoConfig<decimal?>("revistaPeriodicaDescontoPercentagem");


            var diasAposLancamento = (DateTime.Now - DataLancamento).Days;

            #region Sem utilizar o metodo dinamico
            //var valorRevistaPeriodicaDias = Exemplo.ObterValorDoConfig("revistaPeriodicaDescontoAPartirdeDias");
            //int DescontoAPartirdeDias;
            //bool importacaoDiaValido = Int32.TryParse(valorRevistaPeriodicaDias, out DescontoAPartirdeDias);

            //var valorRevistaPeriodicaDesconto = Exemplo.ObterValorDoConfig("revistaPeriodicaDescontoPercentagem");
            //decimal DescontoPercentagem;
            //bool importacaoDescontoValido = Decimal.TryParse(valorRevistaPeriodicaDesconto, out DescontoPercentagem); 

            //if (importacaoDiaValido && importacaoDescontoValido && diasAposLancamento > DescontoAPartirdeDias)
            //{
            //    var preco = base.ObterPreco();
            //    return preco - (preco * (DescontoPercentagem/100));
            //}
            //else
            //{
            //    return base.ObterPreco();
            //}
            #endregion

            if (descontoAPartirdeDias.HasValue && descontoPercentagem.HasValue && diasAposLancamento > descontoAPartirdeDias)
            {
                var preco = base.ObterPreco();
                return preco - (preco * (descontoPercentagem.Value / 100));
            }
            else
            {
                return base.ObterPreco();
            }
        }

        public override string ToString()
        {
            return $"Livro periodico : {Nome}";
        }
    }
}

