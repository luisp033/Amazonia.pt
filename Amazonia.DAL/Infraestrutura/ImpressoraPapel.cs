namespace Amazonia.DAL.Infraestrutura //TODO: Remover impressora desse Projecto
{
    public class ImpressoraPapel : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando impressora em papel");
        }
    }
}

