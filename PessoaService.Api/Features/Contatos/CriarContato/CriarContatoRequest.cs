using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos.CriarContato;

public record CriarContatoRequest(
    string Nome,
    string Email,
    string Telefone,
    ETipoContato TipoContato,
    int PessoaId
);
