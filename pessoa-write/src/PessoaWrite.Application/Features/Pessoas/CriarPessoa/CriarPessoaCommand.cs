using MediatR;

namespace PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public sealed record CriarPessoaCommand (
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade
):IRequest<Guid>;
