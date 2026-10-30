public class Assinatura
{
    // Propriedades imutáveis definidas no construtor
    public string Plano { get; }
    public decimal ValorMensal { get; }
    public int QuantidadeMeses { get; }

    // Inicializadores de valor padrão
    public DateTime DataInicio { get; } = DateTime.Now;
    public bool Ativa { get; private set; } = true;

    // Propriedade calculada (get de expressão)
    public decimal ValorTotal => ValorMensal * QuantidadeMeses;

    public Assinatura(string plano, decimal valorMensal, int quantidadeMeses)
    {
        if (string.IsNullOrWhiteSpace(plano))
        {
            throw new ArgumentException("O plano é obrigatório.", nameof(plano));
        }

        if (valorMensal <= 0m)
        {
            throw new ArgumentException("O valor mensal deve ser positivo.", nameof(valorMensal));
        }

        if (quantidadeMeses <= 0)
        {
            throw new ArgumentException("A quantidade de meses deve ser positiva.", nameof(quantidadeMeses));
        }

        Plano = plano.Trim();
        ValorMensal = valorMensal;
        QuantidadeMeses = quantidadeMeses;
    }

    public void Cancelar()
    {
        if (!Ativa)
        {
            throw new InvalidOperationException("A assinatura já está cancelada.");
        }

        Ativa = false;
    }
}