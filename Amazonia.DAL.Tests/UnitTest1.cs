using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class UnitTest1
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
            var minElementos = 100;

            //Act
            repositorio = new Repositoriolivro();
            livros = repositorio.ObterTodos();
            var quantidadeLivrosNoReppositorio = livros.Count;

            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeLivrosNoReppositorio >= minElementos);



        }
    }
}
