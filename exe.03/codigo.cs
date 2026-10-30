public class Produto
{
    public decimal Preco { get; set; }
}
 
Produto produto = new Produto();
produto.Preco = -50m;

/* Isso não é encapsulamento, o código não protege de por exmplo atribuir um 
preço negativo ao propduto.

a- o Codigo complila sem problemas porém não está em um formato válido 
pois aceitou um valor negativo o que não faz sentido levando em consideração 
a regra de negócio.

b-  Porque ela da acesso total para qualquer lugar do sistema alterar o preço 
como quiser sem nenhuma validação ou regra para proteger o valor.

c-

public class Produto
{
    private decimal _preco;

    public decimal Preco
    {
        get { return _preco; }
        set
        {
            if (value < 0m)
            {
                throw new ArgumentException("O preço não pode ser negativo.");
            }
            _preco = value;
        }
    }
} 

*/

