/* 

a- o compilador gera automaticamente 3 membros, um campo privado oculto Um atributo privado para guardar o valor na memória (ex: <Nome>k__BackingField).
Um método de leitura: O método get_Nome(), que retorna o valor guardado nesse campo privado.
Um método de escrita: O método set_Nome(string value), que recebe o valor e atribui ao campo privado.

b- O que muda: O compilador gera apenas o campo privado (marcado como readonly) e o método de leitura get_Nome(). 
O que não é gerado: O método de escrita set_Nome() NÃO é criado, tornando a propriedade imutável após a inicialização.

c- O atributo campo é o local na memória que realmente armazena o dado. A propriedade não guarda dados por si só. 
ela é apenas um par de meétodos get_nome e set_Nome que encapsula e controla o atributo guardado
na memória. */
