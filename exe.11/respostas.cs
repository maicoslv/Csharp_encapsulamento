/*
a- O estado inválido permite que um pedido fique simultaneamente enviado (enviado =  true)
e cancelado (cancelado =  ture). Ainvariante violada, um pedido cancelado nao pode ser enviado
e um pedido enviado nao poderia ser alterado livremente para o estado de cancelado sem validação.

*/

//b-

public class Pedido
{
    public bool Enviado { get; private set; }
    public bool Cancelado { get; private set; }

    public void Enviar()
    {
        if (Cancelado)
        {
            throw new InvalidOperationException("Não é possível enviar um pedido que já foi cancelado.");
        }

        Enviado = true;
    }

    public void Cancelar()
    {
        if (Enviado)
        {
            throw new InvalidOperationException("Não é possível cancelar um pedido que já foi enviado.");
        }

        Cancelado = true;
    }
}

/*
c- tela de expedição: pedido.enviar();
tela de atendimento: pedido.Cancelar();

*/