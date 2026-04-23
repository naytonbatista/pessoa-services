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
- `Extensions/`: classes de extensão para configuração modular (`ApiExtensions`, `EndpointsExtensions`, `SwaggerExtensions`, `DIExtensions`).
- `Features/`: endpoints organizados por feature (`Pessoas/` com `PessoaEndpoints.cs`, `PessoaRequest.cs`, `PessoaMapper.cs`; `Contatos/` com `ContatoEndpoints.cs`, `ContatoRequest.cs`, `ContatoMapper.cs`).
- `Abstractions/`: interfaces e contratos (`IEndpoint`).
- `Data/`: contexto do Entity Framework e mapeamentos (`AppDbContext`, `Mappings/`).
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

## 3. DTOs (Data Transfer Objects)
- `Features/Pessoas/PessoaRequest.cs`:
  - `Nome` (string)
  - `Email` (string)
  - `Telefone` (string)
  - `DataNascimento` (DateTime)
  - `Ativo` (bool) padrão true
- `Features/Pessoas/PessoaMapper.cs`: métodos de mapeamento entre `PessoaRequest` ↔ `Pessoa`
- `Features/Contatos/ContatoRequest.cs`:
  - `Nome` (string)
  - `Email` (string)
  - `Telefone` (string)
  - `TipoContato` (`ETipoContato`)
  - `PessoaId` (int)
- `Features/Contatos/ContatoMapper.cs`: métodos de mapeamento entre `ContatoRequest` ↔ `Contato`

## 4. Configuração e execução
- API minimal em `Program.cs` com endpoints CRUD para `Pessoa` e `Contato`.
- **Swagger/OpenAPI**: Documentação interativa disponível em `/swagger` (ambiente de desenvolvimento).
- Comandos básicos:
  - `dotnet restore`
  - `dotnet build`
  - `dotnet run`
  - `dotnet test` (projeto de testes não existente ainda)

## 5. Endpoints da API
### Pessoa
- `GET /pessoas` - Lista todas as pessoas com contatos
- `GET /pessoas/{id}` - Obtém pessoa específica por ID
- `POST /pessoas` - Cria nova pessoa
- `PUT /pessoas/{id}` - Atualiza pessoa existente
- `DELETE /pessoas/{id}` - Remove pessoa

### Contato
- `GET /contatos` - Lista todos os contatos com pessoa
- `GET /contatos/{id}` - Obtém contato específico por ID
- `POST /contatos` - Cria novo contato
- `PUT /contatos/{id}` - Atualiza contato existente
- `DELETE /contatos/{id}` - Remove contato

## 6. Dependências e pacotes
- .NET 9.0
- Entity Framework Core 9.0.0 (ORM)
- Npgsql.EntityFrameworkCore.PostgreSQL 9.0.0 (PostgreSQL provider)
- Microsoft.EntityFrameworkCore.Design 9.0.0 (EF Core tools)
- Scrutor 4.0.0 (Dependency injection scanning)
- Swashbuckle.AspNetCore 7.0.0 (Swagger/OpenAPI)
- Dependências gerenciadas em `pessoa-service.csproj`

## 7. Boas práticas e contribuição
- Manter dados sensíveis fora do repositório, preferir variáveis de ambiente.
- Adicionar e versionar `README`/documentação de API ao evoluir.
- Implementar testes unitários/integrados antes de PR.
- Manter consistência de nomenclatura (camelCase, PascalCase) e regras de estilo .NET.

## 8. Próximos passos sugeridos
- Adicionar persistência (EF Core, SQLite/PostgreSQL, etc.).
- Implementar endpoints CRUD para `Pessoa` e `Contato`.
- Adicionar validações de entrada (DataAnnotations ou FluentValidation).
- Implementar migrations e seed de dados.
- Adicionar testes automatizados e CI.

## 9. Observações
- Projeto em estágio inicial e minimalista.
- Modelo `Pessoa` já inclui cálculo de idade e campos de auditoria básicos.
- Expandir camada de serviço / repositório para adoção em produção.
