/* 
a- O número do cartão deve ser obrigatóriamente positivo e nunca altera após a criação.
o Saldo começa sempre em zero e nunca assume valores negativos e nunca ultrapassa o limite
máximo permitido de 500,00.

b- 
+-------------------------------------------------------------+
|                      CartaoTransporte                       |
+-------------------------------------------------------------+
| + Numero: int { get; }                                      |
| + Saldo: decimal { get; private set; }                      |
+-------------------------------------------------------------+
| + CartaoTransporte(numero: int)                             |
| + Recarregar(valor: decimal): void                          |
| + PagarPassagem(tarifa: decimal): void                      |
+-------------------------------------------------------------+
*/

//c-

public class CartaoTransporte
{
    private int _numero;
    private decimal _saldo;

    public int Numero
    {
        get => _numero;
        init
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O número do cartão deve ser positivo.");
            }
            _numero = value;
        }
    }

    public decimal Saldo
    {
        get => _saldo;
        private set => _saldo = value;
    }

    public CartaoTransporte(int numero)
    {
        Numero = numero;
        Saldo = 0m; // O saldo começa obrigatoriamente em zero
    }

    public void Recarregar(decimal valor)
    {
        if (valor <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O valor da recarga deve ser positivo.");
        }

        if (Saldo + valor > 500.00m)
        {
            throw new InvalidOperationException("A recarga ultrapassaria o limite máximo de R$ 500,00 do cartão.");
        }

        Saldo += valor;
    }

    public void PagarPassagem(decimal tarifa)
    {
        if (tarifa <= 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(tarifa), "A tarifa deve ser positiva.");
        }

        if (Saldo < tarifa)
        {
            throw new InvalidOperationException("Saldo insuficiente para pagar a passagem.");
        }

        Saldo -= tarifa;
    }
}

/*
d- 

Cenário de saldo insuficiente:
Catraca --> chama o cartão: cartaoPagarPassagem(5,00)
CArtão --> valida: meu saldo é < que 5,00? Sim
Cartão --. bloqueia e lança uma exception: InvalidOperationException ("Saldo insuficiente")

Cenário 2 com sucesso:
Catraca --> chama o cartão: cartao.PagarPassagem (5,00)
CArtão --> valida: O meu saldo é < que 5,00? Não
Cartão --> altera o estado: subtrai o valor e atualiza o saldo com sucesso.

*/


