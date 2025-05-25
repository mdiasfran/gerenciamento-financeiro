# Gerenciamento Financeiro

Aplicação web desenvolvida em ASP.NET Core MVC para controle simples de finanças pessoais.

## Descrição

Este projeto permite que o usuário registre e acompanhe seus **gastos** e **ganhos**, organizando-os por **categorias**.

### Funcionalidades principais:

- Cadastrar entradas (ganhos) e saídas (gastos)
- Criar e gerenciar categorias de transações
- Filtrar transações por categoria e período
- Visualizar total de ganhos, total de gastos e o saldo (diferença entre eles)

É uma ferramenta simples, útil para controle pessoal de finanças, com foco em praticidade e organização.

## Tecnologias Utilizadas

- ASP.NET Core MVC
- C#
- Entity Framework Core
- Razor Pages
- SQL Server
- HTML, CSS e JavaScript

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/mdiasfran/gerenciamento-financeiro.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd gerenciamento-financeiro
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update
   ```
5. Inicie a aplicação:
   ```bash
   dotnet run
   ```
