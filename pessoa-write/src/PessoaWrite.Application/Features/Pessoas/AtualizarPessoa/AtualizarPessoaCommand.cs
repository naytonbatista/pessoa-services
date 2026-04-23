using MediatR;

namespace PessoaWrite.Application.Features.Pessoas.AtualizarPessoa;

public sealed record AtualizarPessoaCommand (
    Guid Id,
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade
):IRequest<Guid>;
