/*
a- O andar atual do elevador deve estar sempre compreendido entre o térreo e o andar 
máximo definido na criação.
o número de pessoas no interior do elevador deve estar sempre entre o zero
e a capacidade máxima permitida, começando obrigatóriamente vazio.

b- 
+-------------------------------------------------------------+
|                          Elevador                           |
+-------------------------------------------------------------+
| + AndarMaximo: int { get; }                                 |
| + CapacidadePessoas: int { get; }                           |
| + AndarAtual: int { get; private set; }                     |
| + TotalPessoas: int { get; private set; }                   |
| + EstaVazio: bool => TotalPessoas == 0                      |
+-------------------------------------------------------------+
| + Elevador(andarMaximo: int, capacidadePessoas: int)       |
| + Entrar(quantidade: int): void                             |
| + Sair(quantidade: int): void                               |
| + IrPara(andar: int): void                                  |
+-------------------------------------------------------------+
*/

// c------------------ 

public class Elevador
{
    public int AndarMaximo { get; }
    public int CapacidadePessoas { get; }
    public int AndarAtual { get; private set; }
    public int TotalPessoas { get; private set; }

    // Propriedade calculada para informar se não há ninguém no elevador
    public bool EstaVazio => TotalPessoas == 0;

    public Elevador(int andarMaximo, int capacidadePessoas)
    {
        if (andarMaximo < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(andarMaximo), "O andar máximo deve ser maior ou igual a zero.");
        }

        if (capacidadePessoas <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacidadePessoas), "A capacidade de pessoas deve ser positiva.");
        }

        AndarMaximo = andarMaximo;
        CapacidadePessoas = capacidadePessoas;
        AndarAtual = 0;     // Começa no térreo
        TotalPessoas = 0;   // Começa vazio
    }

    public void Entrar(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade de pessoas deve ser positiva.");
        }

        if (TotalPessoas + quantidade > CapacidadePessoas)
        {
            throw new InvalidOperationException("Capacidade máxima excedida. Não cabem tantas pessoas.");
        }

        TotalPessoas += quantidade;
    }

    public void Sair(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade de pessoas deve ser positiva.");
        }

        if (TotalPessoas - quantidade < 0)
        {
            throw new InvalidOperationException("Não podem sair mais pessoas do que as que estão no elevador.");
        }

        TotalPessoas -= quantidade;
    }

    public void IrPara(int andar)
    {
        if (andar < 0 || andar > AndarMaximo)
        {
            throw new ArgumentOutOfRangeException(nameof(andar), $"O andar deve estar entre 0 e {AndarMaximo}.");
        }

        AndarAtual = andar;
    }
}

//d-------------------------

using System;

namespace Exercicio14
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Cria um elevador que vai até ao 10.º andar e suporta no máximo 5 pessoas
            var elevador = new Elevador(10, 5);

            // Sequência de operações válidas
            elevador.Entrar(3);       // Entram 3 pessoas
            elevador.IrPara(4);       // Sobe para o 4.º andar
            elevador.Sair(1);         // Sai 1 pessoa (ficam 2)
            elevador.IrPara(0);       // Desce para o térreo

            Console.WriteLine($"Andar atual: {elevador.AndarAtual}");
            Console.WriteLine($"Total de pessoas: {elevador.TotalPessoas}");
            Console.WriteLine($"Está vazio? {elevador.EstaVazio}");

            /* 
             * OPERAÇÃO QUE SERIA RECUSADA (Lança exceção em execução):
             * elevador.Entrar(10); 
             * Motivo: Ultrapassaria a capacidade máxima de 5 pessoas.
             * 
             * LINHA QUE NÃO COMPILARIA (Erro de compilação por encapsulamento):
             * elevador.AndarAtual = 5; 
             * Motivo: O 'set' da propriedade AndarAtual é privado, impedindo a alteração direta de fora da classe.
             */
        }
    }
}