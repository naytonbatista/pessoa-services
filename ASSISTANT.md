# ASSISTANT - Projeto pessoa-service

Este arquivo descreve as características do projeto `pessoa-service`, oferecendo uma referência rápida para desenvolvedores.

## 1. Visão geral do projeto
- Solução: `pessoa-service.sln`
- Projeto principal: `pessoa-service.csproj`
- Plataforma alvo: .NET 9.0 (`net9.0`)
- Tipo: API/serviço .NET (Console, Web API ou minimal API) com estrutura padrão de configuração.

## 2. Estrutura de pastas e arquivos
- `Program.cs`: ponto de entrada da aplicação.
- `appsettings.json` e `appsettings.Development.json`: configurações de ambiente.
- `Properties/launchSettings.json`: perfis para debug e execução local.
- `Models/`: contém as entidades de domínio (ex: `Pessoa.cs`).
- `bin/` e `obj/`: artefatos de build gerados automaticamente.

## 3. Modelos de domínio atualmente
- `Models/Pessoa.cs`:
  - `Id` (int)
  - `Nome` (string)
  - `Email` (string)
  - `Telefone` (string)
  - `DataNascimento` (DateTime)
  - `Idade` (int, calculado automaticamente)

## 4. Dependências e pacotes
- Gerenciador: NuGet via `pessoa-service.csproj`.
- Framework: .NET 9.0.
- Painel de pacotes: atualizações em `pessoa-service.csproj`.

## 5. Comandos de desenvolvimento
- `dotnet restore`: restaura pacotes NuGet.
- `dotnet build`: compila o projeto.
- `dotnet run`: executa localmente.
- `dotnet test`: executa testes (quando existir projeto de testes).

## 6. Boas práticas e contribuição
- Manter config sensível fora do repositório (usar variáveis de ambiente).
- Atualizar documentação e comentários ao adicionar recursos.
- Testar manualmente e automatizado antes de PR.

## 7. Observações
- O projeto está em estágio inicial com foco em um serviço básico de pessoa.
- Estrutura minimalista preparada para evolução em camadas, APIs e persistência.
