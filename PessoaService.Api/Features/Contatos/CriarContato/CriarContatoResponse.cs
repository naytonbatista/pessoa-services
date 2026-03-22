using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos.CriarContato;

public record CriarContatoResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    ETipoContato TipoContato,
    int PessoaId
);
