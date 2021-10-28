using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class ClienteTests
    {
        [TestMethod()]
        public void NifEstaValidoTest()
        {
            //Arrange
            var cliente =new Cliente();
            cliente.NumeroIdentificacaoFiscal = "193314509";

            //Act
            var nifValido = cliente.NifEstaValido();

            //Assert

            Assert.IsTrue(nifValido);
        }

        [TestMethod()]
        public void DeveInvalidarNifMaiordoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "1933145090";

            //Act
            var nifValido = !cliente.NifEstaValido();

            //Assert

            Assert.IsTrue(nifValido);
        }

        [TestMethod()]
        public void DeveInvalidarNifMenordoQue9Digitos()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "19331450";

            //Act
            var nifValido = !cliente.NifEstaValido();

            //Assert

            Assert.IsTrue(nifValido);
        }

        [TestMethod()]
        public void DeveValidarNifNumerosIguais()
        {
            //Arrange
            var cliente = new Cliente();
            cliente.NumeroIdentificacaoFiscal = "111111111";

            //Act
            var nifValido = !cliente.NifEstaValido();

            //Assert

            Assert.IsTrue(nifValido);
        }

    }
}