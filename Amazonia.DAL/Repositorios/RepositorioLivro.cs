using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorios{

    public class Repositoriolivro : IRepositorio<Livro>
    {
        private readonly List<Livro> ListaLivros;

        public Repositoriolivro()
        {
            ListaLivros = new List<Livro>();
            ListaLivros.Add(new LivroImpresso(){ 
                Nome = "Os Maias", 
                Autor="Eça Quiroz", 
                Descricao ="Romance", 
                Idioma = Idioma.Portugues, 
                Preco= 10.5m, 
                QuantidadePaginas= 1000,
                Dimensoes = new Dimensoes() { Altura = 30.0F, Largura = 18F, Profundidade = 3F, Peso = 0.35F }
            });
            ListaLivros.Add(new LivroDigital(){ 
                Nome = "Lusiadas", 
                Autor="Luiz Camões", 
                Descricao ="Literatura", 
                Idioma = Idioma.Portugues, 
                Preco= 20m, 
                FormatoFicheiro = "pdf",
                TamanhoEmMB = 66,
                InformacoesLicensa = "Proibido copiar"
            });
            ListaLivros.Add(new AudioLivro()
            {
                Nome = "A falar é que a gente se entende",
                Autor = "Descponhecido",
                Descricao = "bla bla bla",
                Idioma = Idioma.Espanhol,
                Preco = 20m,
                DuracaoLivro = 30,
                FornmatoFicheiro = "mp3"
            });
            ListaLivros.Add(new AudioLivro()
            {
                Nome = "Mais um so para testar",
                Autor = "Descponhecido",
                Descricao = "bla bla bla",
                Idioma = Idioma.Espanhol,
                Preco = 20m,
                DuracaoLivro = 30,
                FornmatoFicheiro = "mp3"
            });

            var livroPeriodico = new LivroPeriodico()
            {
                Nome = "Revista Magazine",
                Autor = "Marvel",
                Descricao = "The end of the world",
                Idioma = Idioma.Ingles,
                Preco = 100m,
                DataLancamento = new DateTime(2021,1,1)
            };

            ListaLivros.Add(livroPeriodico);

        }

        public void Apagar(Livro obj)
        {
            if (!ListaLivros.Remove(obj))
            {
                throw new AmazoniaException("Falha ao apagar Livro");
            }
        }

        public Livro Atualizar(string nomeAntigo, string nomeNovo)
        {
            var livroTemporario = ObterPorNome(nomeAntigo);
            livroTemporario.Nome = nomeNovo;
            return livroTemporario;
        }

        public void Criar(Livro obj)
        {
            ListaLivros.Add(obj);
        }

        public Livro ObterPorNome(string Nome)
        {
            var resultado = ListaLivros.FirstOrDefault(x => x.Nome == Nome);
                                      
            return resultado;
        }

        public List<Livro> ObterTodos()
        {
            return ListaLivros;
        }

        public List<Livro> ObterTodosPorIdioma(Idioma idioma)
        {
            var resultado = ListaLivros
                                .Where(x => x.Idioma == idioma)
                                .ToList();
            return resultado;
        }
    }
}