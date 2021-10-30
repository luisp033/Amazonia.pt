namespace Amazonia.DAL.Entidades{
    public abstract class Livro : Entidade
    {
        public decimal Preco { protected get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public Idioma Idioma { get; set; }

        public virtual decimal ObterPreco(){
            return Preco;
        }

        //Poderia ter feito assim, mas preferimos usar a acessibilidade da propriedade
        //public virtual void InformarPreco(decimal precoSemDesconto)
        //{
        //    Preco = precoSemDesconto;
        //}


    }
}