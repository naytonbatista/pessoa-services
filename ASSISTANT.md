# ASSISTANT - Projeto pessoa-service

Este arquivo descreve as características do projeto `pessoa-service`, oferecendo uma referência rápida para desenvolvedores.

## 1. Visão geral do projeto
- Solução: `pessoa-service.sln`
- Projeto principal: `pessoa-service.csproj`
- Plataforma alvo: .NET 9.0 (`net9.0`)
- Tipo: serviço Web API minimal (ASP.NET Core minimal API)

## 2. Estrutura de pastas e arquivos
- `Program.cs`: ponto de entrada da aplicação e definição de rotas API.
- `appsettings.json` e `appsettings.Development.json`: configurações de instalação e ambiente.
- `Properties/launchSettings.json`: perfis de execução local (IIS Express, Projeto).
- `Models/`: entidades de domínio (`Pessoa`, `Contato`).
- `Enums/`: enums de apoio (`ETipoContato`).
- `bin/` e `obj/`: artefatos de build gerados automaticamente.

## 3. Modelos de domínio atuais
- `Models/Pessoa.cs`:
  - `Id` (int)
  - `Nome` (string)
  - `Email` (string)
  - `Telefone` (string)
  - `DataNascimento` (DateTime)
  - `Ativo` (bool) padrão true
  - `CreatedAt` (DateTime) padrão UTC now
  - `UpdatedAt` (DateTime) padrão UTC now
  - `Idade` (int) calculado por `CalcularIdade()`
- `Models/Contato.cs`:
  - `Id` (int)
  - `Nome` (string)
  - `Email` (string)
  - `Telefone` (string)
  - `TipoContato` (`ETipoContato`)
  - `PessoaId` (int)
  - `Pessoa` (navegação opcional)
  - `CreatedAt` (DateTime) padrão UTC now
  - `UpdatedAt` (DateTime) padrão UTC now
- `Enums/ETipoContato.cs`:
  - `Residencial`, `Comercial`, `Celular`, `Emergencia`, `Outro`

## 4. Configuração e execução
- API minimal em `Program.cs` atualmente apenas responde `GET /` com `Hello World!`.
- Comandos básicos:
  - `dotnet restore`
  - `dotnet build`
  - `dotnet run`
  - `dotnet test` (projeto de testes não existente ainda)

## 5. Dependências e pacotes
- .NET 9.0
- Dependências gerenciadas em `pessoa-service.csproj`

## 6. Boas práticas e contribuição
- Manter dados sensíveis fora do repositório, preferir variáveis de ambiente.
- Adicionar e versionar `README`/documentação de API ao evoluir.
- Implementar testes unitários/integrados antes de PR.
- Manter consistência de nomenclatura (camelCase, PascalCase) e regras de estilo .NET.

## 7. Próximos passos sugeridos
- Adicionar persistência (EF Core, SQLite/PostgreSQL, etc.).
- Implementar endpoints CRUD para `Pessoa` e `Contato`.
- Adicionar validações de entrada (DataAnnotations ou FluentValidation).
- Implementar migrations e seed de dados.
- Adicionar testes automatizados e CI.

## 8. Observações
- Projeto em estágio inicial e minimalista.
- Modelo `Pessoa` já inclui cálculo de idade e campos de auditoria básicos.
- Expandir camada de serviço / repositório para adoção em produção.
