namespace Amazonia.DAL{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }
        public string FormatoFicheiro { get; set; } // PDF, DOC, EPUB
        public string InformacoesLicensa { get; set; }

    }
}