using pessoa_service.Enums;

namespace pessoa_service.Features.Contatos
{
    public record ContatoResponse(
        int Id,
        string Nome,
        string Email,
        string Telefone,
        ETipoContato TipoContato,
        int PessoaId
    );
}