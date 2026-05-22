# Projeto Pessoa

Este repositório contém uma implementação de um sistema de gerenciamento de pessoas dividido em dois serviços principais: um serviço de escrita (`pessoa-write`) e um serviço de leitura (`pessoa-read`), além de um projeto de contrato compartilhado (`building-blocks/Pessoa.Contracts`).

## Visão Geral

- `pessoa-write`: serviço responsável pela escrita, criação e enfileiramento de comandos/eventos relacionados a pessoas.
- `pessoa-read`: serviço responsável pela leitura e consulta dos dados de pessoas, consumindo mensagens e mantendo um modelo de leitura otimizado.
- `building-blocks/Pessoa.Contracts`: define contratos compartilhados usados entre os serviços.

## Arquitetura

O projeto segue uma arquitetura de separação de responsabilidades entre leitura e escrita:

- `PessoaWrite.Api`: API REST com endpoints definidos por classes que implementam `IEndpoint`, configurados dinamicamente.
- `PessoaWrite.Application`: camada de aplicação com regras de negócio, validações e orquestração de comandos.
- `PessoaWrite.Domain`: domínio com entidades e objetos de valor do sistema.
- `PessoaWrite.Infrastructure`: infraestrutura de serviço para acesso a dados, injeção de dependência e integrações.
- `PessoaRead.Infrastructure`: utilitários de persistência e consumo de mensagens para o lado de leitura.
- `PessoaRead.Api`: projeto de API para expor o comportamento de leitura de pessoas.

## Tecnologias principais

- .NET 9
- ASP.NET Core Minimal APIs
- MediatR
- MassTransit com RabbitMQ
- Entity Framework Core
- MongoDB via `MongoDB.EntityFrameworkCore`
- Swagger/OpenAPI
- Scrutor para varredura de DI

## Projetos e soluções

Soluções disponíveis:

- `pessoa-read/pessoa-read.sln`
- `pessoa-write/pessoa-write.sln`

Projetos principais:

- `building-blocks/Pessoa.Contracts/Pessoa.Contracts.csproj`
- `pessoa-read/src/PessoaRead.Api/PessoaRead.Api.csproj`
- `pessoa-read/src/PessoaRead.Infrastructure/PessoaRead.Infrastructure.csproj`
- `pessoa-write/src/PessoaWrite.Api/PessoaWrite.Api.csproj`
- `pessoa-write/src/PessoaWrite.Application/PessoaWrite.Application.csproj`
- `pessoa-write/src/PessoaWrite.Domain/PessoaWrite.Domain.csproj`
- `pessoa-write/src/PessoaWrite.Infrastructure/PessoaWrite.Infrastructure.csproj`

## Como executar

1. Abra a solução apropriada no Visual Studio ou VS Code.
2. Execute `pessoa-write` para iniciar o serviço de escrita.
3. Execute `pessoa-read` para iniciar o serviço de leitura.

### Configuração

- `pessoa-write/src/PessoaWrite.Api/appsettings.json`
  - `ConnectionStrings:DefaultConnection` aponta para o banco PostgreSQL.

- `pessoa-read/src/PessoaRead.Api/appsettings.json`
  - Configuração de logging padrão.

- A camada de leitura utiliza MongoDB via EF Core e MassTransit/RabbitMQ para consumo de mensagens.

## Observações

- A API de escrita expõe Swagger em ambiente de desenvolvimento.
- A leitura e escrita são desacopladas, permitindo que a aplicação de leitura consuma eventos e mantenha um modelo de consulta separado.
- O projeto está estruturado para suportar evolução e inclusão de novos endpoints, comandos e consumidores.

## Estrutura de pastas

- `building-blocks/`: contratos e elementos compartilhados.
- `pessoa-write/`: solução e projetos do serviço de escrita.
- `pessoa-read/`: solução e projetos do serviço de leitura.

## Próximos passos

- adicionar documentação de endpoints e contratos de mensagens
- incluir instruções de infraestrutura de RabbitMQ e MongoDB
- documentar o fluxo de eventos entre `pessoa-write` e `pessoa-read`
