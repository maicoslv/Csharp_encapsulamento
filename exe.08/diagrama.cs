/*
+-------------------------------------------------------------+
|                         Assinatura                          |
+-------------------------------------------------------------+
| + Plano: string { get; }                                    |
| + ValorMensal: decimal { get; }                             |
| + QuantidadeMeses: int { get; }                             |
| + DataInicio: DateTime { get; } = DateTime.Now              |
| + Ativa: bool { get; private set; } = true                  |
| + ValorTotal: decimal => ValorMensal * QuantidadeMeses      |
+-------------------------------------------------------------+
| + Assinatura(plano: string, valorMensal: decimal, meses: int)|
| + Cancelar(): void                                          |
+-------------------------------------------------------------+
*/

/*

c- Prevaleceria o valor do atributo no construtor, por que na ordem de
execução do c# os inicializadores de propriedade sao executador priemiro.
em seguida o código do construtor é executado, sobresscrevendo qualquer valor que 
tenha sido atribuido anteriormente pelo inicializador. 

*/