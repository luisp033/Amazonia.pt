using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Desconto;
using System.Configuration;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosImpressosTest()
        {

            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 02" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert
            Assert.AreEqual(valorEsperado, valorObtido);

        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {

            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 54M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert
            Assert.AreEqual(valorEsperado, valorObtido);

        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressosTest()
        {

            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital 01" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital 02" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital 03" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso 04" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso 05" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso 06" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 114M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert
            Assert.AreEqual(valorEsperado, valorObtido);

        }

        [TestMethod()]
        [Ignore]
        public void AplicarDescontoTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso 02" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 80M;
            var valorDesconto = 20;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObitidoDesconto= carrinho.AplicarDesconto(null); // valorDesconto

            //Assert
            Assert.AreEqual(valorEsperado, valorObitidoDesconto);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosPeriodicosTest()
        {

            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroPeriodico { Preco = 10, Nome = "Periodico 01", DataLancamento = DateTime.Now.AddDays(-30) });
            livrosFake.Add(new LivroPeriodico { Preco = 20, Nome = "Periodico 02", DataLancamento = DateTime.Now });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 29M;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //Assert
            Assert.AreEqual(valorEsperado, valorObtido);

        }

        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso 02" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 80M;

            var desconto = new DescontoPercentual();
            desconto.PercentualDesconto = 20;

            //Act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObitidoDesconto = carrinho.AplicarDesconto(desconto);

            //Assert
            Assert.AreEqual(valorEsperado, valorObitidoDesconto);
        }

        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualECombinadoTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso 02" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            carrinho.Livros = livrosFake;

            var descontoPercentual = new DescontoPercentual();
            descontoPercentual.PercentualDesconto = 20;
            var valorObitidoDescontoPercentual = carrinho.AplicarDesconto(descontoPercentual);

            var descontoCombinado = new DescontoCombinado();
            descontoCombinado.PercentualDesconto = 20;
            descontoCombinado.LivrosCarrinho = livrosFake;
            descontoCombinado.LivrosDigitais = 1;
            descontoCombinado.LivrosImpressos = 2;


            var valorObitidoDescontoCombinado = carrinho.AplicarDesconto(descontoCombinado);

        }

        [TestMethod()]
        public void AplicarDescontoExemploDescontoPercentualECombinadoComBasenoConfigTest()
        {
            //Arrange
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso 01" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso 02" });
            livrosFake.Add(new LivroDigital{ Preco = 100, Nome = "Digital 01" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            carrinho.Livros = livrosFake;

            IDesconto desconto;

            //var condicao = false; // Introduca ao dependency injection/

            var condicao = ConfigurationManager.AppSettings["RegraDescontoValida"] == "Percentual";

            if (condicao) 
            { 
                desconto = new DescontoPercentual { 
                    PercentualDesconto = 10
                };
            }
            else
            {
                desconto = new DescontoCombinado
                {
                    PercentualDesconto = 20,
                    LivrosCarrinho = livrosFake,
                    LivrosDigitais = 1,
                    LivrosImpressos = 2
                };
            }

            var valorObitidoDesconto= carrinho.AplicarDesconto(desconto);

            //Assert
            if (condicao) 
            {
                Assert.AreEqual(171,valorObitidoDesconto);
            }
            else
            {
                Assert.AreEqual(152, valorObitidoDesconto);
            }


        }
    }
}