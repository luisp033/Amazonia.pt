using System;
using System.Linq;

namespace Amazonia.DAL.Entidades{
    public class Cliente : Entidade
    {
 
        public Morada Morada { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }      
        public DateTime Datanascimento {get; set;}  


        public int Idade => DateTime.Now.Year - Datanascimento.Year;

        public string  NumeroIdentificacaoFiscal{ get; set; }
        public bool NifEstaValido() 
        {

            if (NumeroIdentificacaoFiscal.Length != 9)
                return false;

            if (NumeroIdentificacaoFiscal.ToCharArray().Distinct().ToList().Count == 1)
                return false;
            /*
            //var produtoSomatorio = 0
            //var fatorMultiplicacao = 2
            //for (int i = NumeroIdentificacaoFiscal.Length-2; i > 0; i--)
            //{
            //    int elemento = Convert.ToInt32((NumeroIdentificacaoFiscal[i].ToString()));
            //    var produto = elemento * fatorMultiplicacao;
            //    produtoSomatorio += produto;
            //    fatorMultiplicacao++;
            //}

            //var restoDivisaoPor11 = produtoSomatorio % 11;
            //if ((restoDivisaoPor11 == 0 || restoDivisaoPor11 == 1) && Convert.ToInt32((NumeroIdentificacaoFiscal[8].ToString())) == 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return (11 - restoDivisaoPor11) == Convert.ToInt32((NumeroIdentificacaoFiscal[8].ToString()));
            //}
            */

            return true;
        }




    }
}