/* 
a- Retira 80m como o codigo original faz alteração (volume -= litrps)
antes da validação, o volume na memória passa a ser -30, em seguida a validação 
deteta o erro e lança uma exception. O pronlema é que o objeto fica num estado inválido, 
mesmo tendo gerado um erro. 

Retirar - 10m o volme passa incorretamente para 60 pq subtrai o numero
negativo da soma total antes de validar, depois a exceção é lançada mas o objeto ja foi 
modificado incorretamente. */


//b- 

public void Retirar(decimal litros)
{
    if (litros <= 0m)
    {
        throw new ArgumentOutOfRangeException(nameof(litros), "A quantidade a retirar deve ser positiva.");
    }

    if (Volume < litros)
    {
        throw new InvalidOperationException("Volume insuficiente.");
    }

    // Altera o estado apenas após passar por todas as validações
    Volume -= litros;
}


//c- 

public class Reservatorio
{
    public decimal Capacidade { get; }
    public decimal Volume { get; private set; }

    public Reservatorio(decimal capacidade)
    {
        if (capacidade <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(capacidade), "A capacidade deve ser positiva.");
        }

        Capacidade = capacidade;
        Volume = 0m; // Volume inicial zero
    }

    public void Encher(decimal litros)
    {
        if (litros <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(litros), "A quantidade a encher deve ser positiva.");
        }

        if (Volume + litros > Capacidade)
        {
            throw new InvalidOperationException("A quantidade excede a capacidade máxima do reservatório.");
        }

        Volume += litros;
    }

    public void Retirar(decimal litros)
    {
        if (litros <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(litros), "A quantidade a retirar deve ser positiva.");
        }

        if (Volume < litros)
        {
            throw new InvalidOperationException("Volume insuficiente.");
        }

        Volume -= litros;
    }
}

/*d-

ArgumentOutOfRangeException: É usada quando o problema está no
argumento/parâmetro fornecido pelo utilizador (por exemplo, passar um valor negativo
ou zero em litros ou capacidade). O dado em si é inválido por definição.
InvalidOperationException: É usada quando o argumento passado é válido, mas o
estado atual do objeto não permite realizar a ação naquele momento (por exemplo,
tentar retirar mais água do que o volume existente, ou encher além da capacidade).
*/