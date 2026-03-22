using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos.ObterContatos;

public record ObterContatosResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    ETipoContato TipoContato,
    int PessoaId
);
