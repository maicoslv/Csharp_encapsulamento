/*
a- public class Termometro
{
    private decimal _temperatura;
}
O que deixa de funcionar, quem usa a classe não consegue mais acessar ou alterar
o valor do atributo diretamente de fora.

b- public class Termometro
{
    private decimal _temperatura;

    public decimal ObterTemperatura()
    {
        return _temperatura;
    }

    public void AlterarTemperatura(decimal valor)
    {
        if (valor < -273.15m)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "A temperatura não pode ser menor que o zero absoluto (-273,15 °C).");
        }
        _temperatura = valor;
    }
} 

c- public class Termometro
{
    private decimal _temperatura;

    public decimal Temperatura
    {
        get
        {
            return _temperatura;
        }
        set
        {
            if (value < -273.15m)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "A temperatura não pode ser menor que o zero absoluto (-273,15 °C).");
            }
            _temperatura = value;
        }
    }
}

d- Poque a propriedade aumtomatica não premite adicionar lógica personalizada
de validação. Precisamos verificar se o valor pe menor que -273,15 °C dentro do set antes
de salvar o que exige um campo provado e o corpo explicito no set.