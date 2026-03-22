using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos.AtualizarContato;

public record AtualizarContatoResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    ETipoContato TipoContato,
    int PessoaId
);
