/*
a- O código e Nome são obrigatórios e nunca mudam após a criação do produto.
o Preço nunca pode assumir um valor nagetivo. O Estoque começa obrigatoriamente 
em zero e nunca pode ficar com valor negativo.

b- Diagrama de classe: 
+-------------------------------------------------------------+
|                           Produto                           |
+-------------------------------------------------------------+
| + Codigo: string { get; }                                   |
| + Nome: string { get; }                                     |
| + Preco: decimal { get; set; }                              |
| + Estoque: int { get; private set; }                        |
+-------------------------------------------------------------+
| + Produto(codigo: string, nome: string, preco: decimal)     |
| + AdicionarEstoque(quantidade: int): void                   |
| + RemoverEstoque(quantidade: int): void                     |
+-------------------------------------------------------------+
*/

//c- 
public class Produto
{
    private string _codigo = string.Empty;
    private string _nome = string.Empty;
    private decimal _preco;

    public string Codigo
    {
        get => _codigo;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O código é obrigatório.", nameof(value));
            }
            _codigo = value.Trim().ToUpper();
        }
    }

    public string Nome
    {
        get => _nome;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome é obrigatório.", nameof(value));
            }
            _nome = value.Trim();
        }
    }

    public decimal Preco
    {
        get => _preco;
        set
        {
            if (value < 0m)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O preço não pode ser negativo.");
            }
            _preco = value;
        }
    }

    public int Estoque { get; private set; } = 0; // Começa em zero

    public Produto(string codigo, string nome, decimal preco)
    {
        Codigo = codigo;
        Nome = nome;
        Preco = preco; // Passa pelo setter que valida o preço
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade a adicionar deve ser positiva.");
        }

        Estoque += quantidade;
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade a remover deve ser positiva.");
        }

        if (Estoque < quantidade)
        {
            throw new InvalidOperationException("Estoque insuficiente para a remoção.");
        }

        Estoque -= quantidade;
    }
}

//d-

using System;

namespace Exercicio12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Cadastra o produto
            var produto = new Produto("p001", "Teclado Mecânico", 150.00m);

            // Movimenta o estoque
            produto.AdicionarEstoque(10);
            produto.RemoverEstoque(3);

            Console.WriteLine($"Produto: {produto.Nome} ({produto.Codigo})");
            Console.WriteLine($"Preço: R$ {produto.Preco}");
            Console.WriteLine($"Estoque atual: {produto.Estoque}");

            // LINHA QUE NÃO COMPILA POR CAUSA DO ENCAPSULAMENTO:
            // produto.Estoque = 50; 
            // Erro: O modificador 'private' impede acesso externo ao set da propriedade Estoque.
        }
    }
}