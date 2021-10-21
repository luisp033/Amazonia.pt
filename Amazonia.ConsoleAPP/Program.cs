using System;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorios;


namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Consulta do DB");

            var repo = new RepositorioCliente();

            // var listaClientes = repo.ObterTodos();
             //var listaClientes = repo.ObterTodosQueComecemPor("M");
            var listaClientes =repo.ObterTodosQueTenhamPeloMenosXAnos(18);
            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            var listaClientes2= repo.ObterTodosNomesQueTenhamPeloMenosXAnos(18);
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

            var clienteNovo = repo.Atualizar("Maria", "Joao da Silva");

            var listaClientes3 = repo.ObterTodos();
            foreach (var item in listaClientes3)
            {
                Console.WriteLine(item);
            }

            // Console.WriteLine("Criacao de novos cliente no DB");
            // do{
            //     var novoCliente = new Cliente();

            //     Console.Write("Informe Nome:");
            //     novoCliente.Nome = Console.ReadLine();
            //     repo.Criar(novoCliente);

            // }while(Console.ReadKey().Key != ConsoleKey.Tab);


            // var listaClientesNovosEAntigos = repo.ObterTodos();

            // foreach (var item in listaClientesNovosEAntigos)
            // {
            //     Console.WriteLine(item);
            // }

        }
    }
}
