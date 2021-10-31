using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorios{

    public class RepositorioCliente : IRepositorio<Cliente> 
    {

        private readonly List<Cliente> ListaClientes;

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
             ListaClientes.Remove(obj);
        }


        public Cliente Atualizar(string nomeAntigo, string nomeNovo)
        {
            var clienteTemporario = ObterPorNome(nomeAntigo);
            clienteTemporario.Nome = nomeNovo;
            return clienteTemporario;
        }


        public void Criar(Cliente obj)
        {
            ListaClientes.Add(obj);
        }

        public Cliente ObterPorNome(string Nome)
        {
            var resultado = ListaClientes
                                    .Where(x => x.Nome == Nome)
                                    .OrderBy(x=>x.Idade)
                                    .FirstOrDefault();
            return resultado;
        }

        public List<Cliente> ObterTodos()
        {
            return ListaClientes;
        }

        public List<Cliente> ObterTodosQueComecemPor(string comeco)
        {
            var resultado = ListaClientes
                                .Where(x => x.Nome.StartsWith(comeco))
                                .ToList();
            return resultado;
        }

        public List<Cliente> ObterTodosQueTenhamPeloMenosXAnos(int idade)
        {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenosXAnos");
            var resultado = ListaClientes
                                .Where(x => x.Idade > idade)
                                .ToList();
            return resultado;
        }

        public List<string> ObterTodosNomesQueTenhamPeloMenosXAnos(int idade)
        {
            System.Console.WriteLine("ObterTodosNomesQueTenhamPeloMenosXAnos");
            var resultado = ListaClientes
                                .Where(x => x.Idade > idade)
                                .Select(x => x.Nome.ToUpper())
                                .ToList();
            return resultado;
        }

        public static void GerarRelatorio(IImpressora impressora)
        {
            impressora.Imprimir();
        }

    }
}