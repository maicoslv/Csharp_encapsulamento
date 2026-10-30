public class Cliente
{
    private string _nome = string.Empty;
    private string _email = string.Empty;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome é obrigatório.");
            }
            _nome = value.Trim();
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O e-mail é obrigatório.");
            }
            _email = value.Trim().ToLower();
        }
    }

    // Construtor que reutiliza as propriedades para aplicar as mesmas regras
    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}