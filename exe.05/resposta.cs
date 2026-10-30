/*

a- public string Cpf { get; init; };
o modificador init permite definir o valor apenas na criação do objeto e impede
qualque alteração depois disso.

b- public int QuantidadeEstoque { get; private set; };
o private set impede que o estoque seja alterado diretamente de fora da classe
obrigando o uso de métodos como AdicionarEstoque ou RemoverEstoque para controlar o saldo

c- public DateTime DataCadastro { get; } = DateTime.Now;
uma propriedade somente leitura get inicializada diretamente com a data e hora 
atual nom momento da criação do objeto garante que a data nunca seja modificada.

d- public string cliente { get; set; };
como é um campo livre sem regras de validação, uma auto-property simples
com get e set publicos resolve perfeitamente.

e- public decimal PrecoComDesconto => Preco - (Preco * (PercentualDesconto / 100m));
É uma propriedade calculada somente com get de expressão, como o valor depende de outros 
dados ele não deve ser armazenado e sim calculado na hora da leitura.

f- public string Senha { set => _senha = value; };
Ao omitir o get ou deixar ele inacessível a propriedade fica disponível 
apenas para escrita impedidno que qualquer código externo leia o valor da senha. 

*/ 