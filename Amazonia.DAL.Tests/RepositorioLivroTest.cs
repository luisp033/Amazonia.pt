using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class RepositorioLivroTest
    {

        [TestMethod]
        public void DeveCriarUmObjectoDoTipoReposotorioLivros()
        {
            //Arrange
            Repositoriolivro repositorio;

            //Act
            repositorio = new Repositoriolivro();

            //Assert
            Assert.IsNotNull(repositorio);
        }

        [TestMethod]
        public void DeveCriarUmaListaDeLivrosDoTipoReposotorioLivros()
        {
            //Arrange
            Repositoriolivro repositorio;
            List<Livro> livros;
            var minElementos = 1;

            //Act
            repositorio = new Repositoriolivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoReppositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeLivrosNoReppositorio >= minElementos);
        }


        [Ignore] //TODO: Modificar esse teste quando a action estiver ok no Github
        [TestMethod]
        public void DeveCriarUmaListaDeLivrosDoTipoReposotorioLivrosComFalha()
        {
            //Arrange
            Repositoriolivro repositorio;
            List<Livro> livros;
            var quantidadeElementos = 3;

            //Act
            repositorio = new Repositoriolivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoReppositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            //Assert.IsTrue(quantidadeElementos == quantidadeLivrosNoReppositorio);
            Assert.AreEqual(quantidadeElementos, quantidadeLivrosNoReppositorio);
        }


        [TestMethod]
        public void DeveApagarUmLivroDaLista()
        {
            //Arrange
            var repo = new Repositoriolivro();
            var livros = repo.ObterTodos();
            var livroAApagar = livros.FirstOrDefault();

            //Act
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroAApagar);
            var livrosDepoisDeApagar = livros.Count;

            //Assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }


#if !DEBUG
        [Ignore]
#endif
        [TestMethod]
        [ExpectedException(typeof(AmazoniaException))]
        public void DeveGerarExceptionQuantoTentaApagarLivroInexistente()
        {
            //Arrange
            var repo = new Repositoriolivro();
            var livros = repo.ObterTodos();
            Livro livroInexistente = new LivroDigital();

            //Act
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroInexistente);
            var livrosDepoisDeApagar = livros.Count;

            //Assert
            Assert.IsTrue(livrosInicialmente > livrosDepoisDeApagar);
        }


    }
}
