using System;
namespace Amazonia.DAL.Entidades{
    public class Cliente : Entidade
    {
 
        public Morada Morada { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }      
        public DateTime Datanascimento {get; set;}  


        public int Idade => DateTime.Now.Year - Datanascimento.Year;    



    }
}