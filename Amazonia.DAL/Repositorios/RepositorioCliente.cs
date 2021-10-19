using System.Collections.Generic;

namespace Amazonia.DAL.Repositorios{

    public class RepositorioCliente : IRepositorio<Cliente>
    {

        private List<Cliente> ListaClientes;

        public RepositorioCliente()
        {
            ListaClientes = new List<Cliente>();

            var joao = new Cliente{Nome="Joao", Datanascimento = new System.DateTime(1980,1,1)};
            var maria = new Cliente{Nome="Maria", Datanascimento = new System.DateTime(1990,1,1)};
            var marta = new Cliente{Nome="Marta", Datanascimento = new System.DateTime(1970,1,1)};

            ListaClientes.Add(joao);
            ListaClientes.Add(maria);
            ListaClientes.Add(marta);
        }

        public void Apagar(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public Cliente Atualizar(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public void Criar(Cliente obj)
        {
            ListaClientes.Add(obj);
        }

        public Cliente ObterPorNome(string Nome)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            return ListaClientes;
        }
    }
}