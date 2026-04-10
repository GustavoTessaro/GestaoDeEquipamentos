# 📦 Sistema de Gestão de Equipamentos (C#)

## 📖 Descrição
Este projeto é um sistema de console desenvolvido em C# para **gerenciamento de equipamentos e manutenções**.  
Ele permite cadastrar usuários, realizar login e controlar equipamentos associados a cada usuário, além de registrar manutenções.

Os dados são persistidos em um arquivo **JSON (`usuario.json`)**, garantindo armazenamento simples e eficiente.

---

## 🚀 Funcionalidades

### 👤 Usuários
- Cadastro de novos usuários
- Login com nome e senha
- Persistência em arquivo JSON

### 🖥️ Equipamentos
- Cadastrar equipamento
- Editar equipamento
- Excluir equipamento
- Visualizar equipamentos

### 🔧 Manutenções
- Cadastrar manutenção
- Editar manutenção
- Excluir manutenção
- Visualizar manutenções
- Verificação automática de manutenção (a cada 180 dias)

---

## 💾 Persistência de Dados

O sistema utiliza:
```csharp
System.Text.Json
```

### Métodos principais:
- `salvarUsuario()` → salva os dados no arquivo JSON
- `lerUsuarios()` → lê os dados do arquivo JSON
- `AtualizarUsuario()` → atualiza dados do usuário após alterações

---

## 🧠 Estrutura do Sistema

### 🔹 Classe `Program`
Responsável por:
- Controle do fluxo do sistema
- Menus principais
- Login e cadastro
- Navegação entre funcionalidades

---

### 🔹 Classe `Usuario`

Representa um usuário do sistema.

#### Atributos:
- `nome`
- `senha`
- `equipamentos`
- `manutencoes`

#### Métodos principais:

##### Equipamentos
- `CadastrarEquipamento()`
- `EditarEquipamento()`
- `ExcluirEquipamento()`
- `MostrarEquipamentos()`

##### Manutenções
- `CadastrarManutencao()`
- `EditarManutencao()`
- `ExcluirManutencao()`
- `MostrarManutencoes()`

##### Extra
- `VerificarManutencoes()` → verifica automaticamente equipamentos sem manutenção há mais de 180 dias

---

### 🔹 Classe `Equipamento`

Representa um equipamento cadastrado.

#### Atributos:
- `ID`
- `nome`
- `preco`
- `fabricante`
- `dataFabricacao`
- `EstaEmManutencao`
- `ultimaVezManutencao`

---

### 🔹 Classe `ManutencaoEquipamento`

Herda de `Equipamento`.

#### Atributos adicionais:
- `titulo`
- `descricao`
- `dataAbertura`
- `diasDesdeAbertura`

#### Método:
- `CalcularDiasDesdeAbertura()`

---

## 📋 Fluxo do Sistema

1. Usuário inicia o programa
2. Escolhe:
   - Login
   - Cadastro
   - Sair
3. Após login:
   - Menu Equipamentos
   - Menu Manutenção
   - Logout
4. Sistema salva automaticamente alterações

---

## ⚠️ Tratamento de Erros

O sistema utiliza `try/catch` para evitar falhas em:
- Entrada de dados inválidos
- Conversões (int, float, DateTime)

---

## 📁 Estrutura de Arquivos

```
📦 Projeto
 ┣ 📜 Program.cs
 ┣ 📜 usuario.json
 ┗ 📜 README.md
```

---

## ▶️ Como Executar

1. Compile o projeto:
```bash
dotnet build
```

2. Execute:
```bash
dotnet run
```

---

## 💡 Observações

- IDs de equipamentos e manutenções são inseridos manualmente
- O sistema roda totalmente no console
- Não utiliza banco de dados, apenas JSON

---

## 📌 Possíveis Melhorias

- Validação mais robusta de entradas
- Interface gráfica (GUI)
- Banco de dados (SQL)
- Sistema de autenticação mais seguro
- Geração automática de IDs

