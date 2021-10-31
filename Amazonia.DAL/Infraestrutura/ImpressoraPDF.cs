namespace Amazonia.DAL.Infraestrutura //TODO: Remover impressora desse Projecto
{
    public class ImpressoraPdf : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando impressoar pdf");
        }
    }
}

