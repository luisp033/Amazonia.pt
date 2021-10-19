namespace Amazonia.DAL{
    public class Dimensoes
    {

        /// Largura em centimetros
        public float Largura { get; set; }
        /// Altura em centimetros
        public float Altura { get; set; }
        /// Profundidade em centimetros
        public float Profundidade { get; set; }
        /// Peso  em gramas
        public float Peso { get; set; }

        public float Volume => Largura * Altura * Profundidade;

        public float ObterVolume(){
            return Largura * Altura * Profundidade;
        } 

    }
}