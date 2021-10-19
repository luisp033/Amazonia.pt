using System;
using Amazonia.DAL;
using Amazonia.DAL.Repositorios;


namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Consulta do DB");

            var repo = new RepositorioCliente();

            var listaClientes = repo.ObterTodos();

            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Criacao de novos cliente no DB");
            do{
                var novoCliente = new Cliente();

                Console.Write("Informe Nome:");
                novoCliente.Nome = Console.ReadLine();
                repo.Criar(novoCliente);

            }while(Console.ReadKey().Key != ConsoleKey.Tab);

            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            var listaClientesNovosEAntigos = repo.ObterTodos();

            foreach (var item in listaClientesNovosEAntigos)
            {
                Console.WriteLine(item);
            }

        }
    }
}
