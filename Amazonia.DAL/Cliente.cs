using System;
namespace Amazonia.DAL{

    public class Cliente
    {
        public string Nome { get; set; }
        public Morada Morada { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }      
        public DateTime Datanascimento {get; set;}  


        public int Idade => DateTime.Now.Year - Datanascimento.Year;    

        public override string ToString(){
            
            return $"Nome: {Nome} => Idade: {Idade}";
        }

    }
}