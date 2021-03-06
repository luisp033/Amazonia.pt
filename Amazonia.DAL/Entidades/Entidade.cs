using System;

namespace Amazonia.DAL.Entidades
{
    public abstract class Entidade
    {
        public Guid Identificador { get; }
        public string Nome { get; set; }
        
        protected Entidade()
        {
            Identificador  = Guid.NewGuid();             
        }

        protected Entidade(string nome)
        {
            Nome = nome;
            Identificador  = Guid.NewGuid();     
        }

        public override string ToString(){
            
            return $"Nome: {Nome} => Id: {Identificador}";
        }
    }
}