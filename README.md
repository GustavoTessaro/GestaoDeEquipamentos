# Gestão de Equipamentos

Este projeto em C# é um sistema simples de gerenciamento de equipamentos com autenticação de usuários e armazenamento de dados em arquivo JSON.

## Estrutura do projeto

- `GestaoDeEquipamentos/Program.cs`
  - Contém o ponto de entrada do programa.
  - Gerencia o fluxo de login, cadastro de usuários e o menu de operações.
  - Lê e grava usuários em `usuario.json` usando serialização JSON.

- `GestaoDeEquipamentos/Usuario.cs`
  - Define a classe `Usuario` com nome, senha e uma lista de equipamentos.
  - Implementa ações de usuário como cadastrar, editar, excluir e mostrar equipamentos.

- `GestaoDeEquipamentos/Equipamentos.cs`
  - Define a classe `Equipamentos` com propriedades: ID, nome, preço, fabricante e data de fabricação.
  - Fornece getters e setters para cada campo.

## Como funciona

1. Ao iniciar o programa, o usuário escolhe entre:
   - Fazer login
   - Cadastrar novo usuário
   - Sair

2. Após o login, o usuário vê um menu de gestão de equipamentos com opções:
   - Cadastrar equipamento
   - Editar equipamento
   - Excluir equipamento
   - Visualizar equipamentos
   - Logout

3. Cada usuário tem seu próprio conjunto de equipamentos.
   - As alterações de equipamentos são salvas no arquivo `usuario.json`.
   - O sistema atualiza os dados do usuário autenticado sempre que um equipamento é cadastrado, editado ou excluído.

## Recursos principais

- Login e cadastro de usuário.
- Persistência de dados em arquivo JSON (`usuario.json`).
- Cadastro de equipamentos com validação de entrada.
- Edição e exclusão por ID do equipamento.
- Visualização de todos os equipamentos cadastrados pelo usuário.

## Execução

1. Abra o projeto no Visual Studio ou outro editor C# compatível.
2. Compile a solução `GestaoDeEquipamentos.slnx`.
3. Execute o projeto `GestaoDeEquipamentos`.

O programa roda em console e interage com o usuário por meio de entradas de texto.

## Observações

- O arquivo `usuario.json` é criado na mesma pasta onde o programa é executado.
- Ao cadastrar um usuário, o sistema salva imediatamente os dados.
- A edição e exclusão de equipamento usam o `ID` informado pelo usuário.
- Se a entrada for inválida durante cadastro ou edição, o programa exibe uma mensagem de erro e pede nova tentativa.
