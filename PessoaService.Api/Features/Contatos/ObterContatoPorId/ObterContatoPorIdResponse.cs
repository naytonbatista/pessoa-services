using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos.ObterContatoPorId;

public record ObterContatoPorIdResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    ETipoContato TipoContato,
    int PessoaId
);
