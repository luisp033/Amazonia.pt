using System.Collections.Generic;
using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios{
    interface ICarrinhoCompras
    {

        decimal CalcularPreco();

        //comentado apenas para guardar o exemplo
        //decimal AplicarDesconto(decimal valorDesconto); 

        decimal AplicarDesconto(IDesconto tipoDeDesconto); 

    }
}