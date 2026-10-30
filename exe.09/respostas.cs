/*
a----
Turma ( código, número de vagas, alunos matriculados)
invariante 1: o número de variantes nunca pode ser superior ao número total de vagas.
Operação que violaria: o método de matricular um aluno (se não validasse previamente
se o limite de vagas já foi atingido).
invariante 2: o número de vagas não pode ser um valor negativo. Operação que violaria:
o método de definir ou alterar o número de vagas (se aceitasse um número abaixo de zero).

b---
Ingresso de um show (setor, preço se já foi utilizado)
invariante 1: O preço do ingresso não pode ser negativo.
operação que violaria : o construtor ouy metodo de alterar o preço se permitisse
valores menores que zero.
invariante 2: um ingresso não pode ser ultilizado mais que uma vez.
operação que violaria: o método de validar/usar o ingreeso na entrada se não verificasse 
o estado JaFoiUltilizado, já está ativo.

c-----
reservatório de água (capacidade, volume atual)
invariante 1: O volume de agua nunca pode ultrapassar a capacidade máxima.
operação que violaria: o método de encher o reservatório se permitisse adicionar
mais água do que o espaço disponível.
invariante 2: o volume atual nunca pode ser menor que zero.
operação que violaria: o Método de retirar água se permitisse remover mais água do que
a quantidade efetivamete existente.
*/
