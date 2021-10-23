namespace Amazonia.DAL.Entidades{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }
        public string FormatoFicheiro { get; set; } // PDF, DOC, EPUB
        public string InformacoesLicensa { get; set; }

        public override decimal ObterPreco(){
            return base.ObterPreco() * 0.9M;
        }

        public override string ToString()
        {
            return $"Livro Digital : {base.ToString()} InformacoesLicensa : {InformacoesLicensa}";
        }   


    }
}