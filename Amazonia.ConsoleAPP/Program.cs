using System;
using System.Configuration;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorios;
using Amazonia.DAL.Utils;

namespace Amazonia.ConsoleAPP
{
    public static class Program
    {
        static void Main(string[] args)
        {

            
            var usarRegranovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegranova = Convert.ToBoolean(usarRegranovaStr);

            if (!usarRegranova) 
            {
                var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");
                ListarClientes();
                Console.WriteLine(valorObtidoPeloMetodo);
            }
            else
            {
                ListarLivros();
            }


        }

        public static void ListarLivros()
        {
            var repoLivros = new Repositoriolivro();

            System.Console.WriteLine("---------------------[Todos os Livros]");
            var listaLivros1 = repoLivros.ObterTodos();
            foreach (var item in listaLivros1)
            {
                Console.WriteLine($"{item} Preço: {item.ObterPreco()}" );
            }

            System.Console.WriteLine("---------------------[Livros em português]");
            var listaLivros2 = repoLivros.ObterTodosPorIdioma(DAL.Idioma.Portugues);
            foreach (var item in listaLivros2)
            {
                Console.WriteLine(item);
            }

        }
        public static void ListarClientes()
        {
            Console.WriteLine("Consulta do DB");

            var repo = new RepositorioCliente();
            

            // var listaClientes = repo.ObterTodos()
            //var listaClientes = repo.ObterTodosQueComecemPor("M")
            var listaClientes = repo.ObterTodosQueTenhamPeloMenosXAnos(18);
            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            var listaClientes2 = repo.ObterTodosNomesQueTenhamPeloMenosXAnos(18);
            foreach (var item in listaClientes2)
            {
                Console.WriteLine(item);
            }

            System.Console.WriteLine("---------------------");
            var joao = repo.ObterPorNome("Joao");
            System.Console.WriteLine(joao);

            System.Console.WriteLine("---------------------");
            repo.Apagar(joao);

            System.Console.WriteLine("---------------------");

            //var clienteNovo = repo.Atualizar("Maria", "Joao da Silva")

            var listaClientes3 = repo.ObterTodos();
            foreach (var item in listaClientes3)
            {
                Console.WriteLine(item);
            }



        }

    }
}
