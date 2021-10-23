namespace Amazonia.DAL.Infraestrutura //TODO: Remover impressora desse Projecto
{
    public class ImpressoraPDF : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando impressoar pdf");
        }
    }
}

