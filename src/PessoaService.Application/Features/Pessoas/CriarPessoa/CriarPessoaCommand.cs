using MediatR;

namespace PessoaService.Application.Features.Pessoas.CriarPessoa;

public sealed record CriarPessoaCommand (
    string Nome,
    string Email,
    string Telefone,
    DateTime DataNascimento,
    bool Ativo = true
):IRequest<Unit>;
