using pessoa_service.Features.Contatos;
using pessoa_service.Models;

namespace pessoa_service.Features.Contatos
{
    public static class ContatoMapper
    {
        public static Contato ToEntity(this ContatoRequest request)
        {
            return new Contato
            {
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                TipoContato = request.TipoContato,
                PessoaId = request.PessoaId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(this Contato contato, ContatoRequest request)
        {
            contato.Nome = request.Nome;
            contato.Email = request.Email;
            contato.Telefone = request.Telefone;
            contato.TipoContato = request.TipoContato;
            contato.PessoaId = request.PessoaId;
            contato.UpdatedAt = DateTime.UtcNow;
        }

        public static ContatoRequest ToRequest(this Contato contato)
        {
            return new ContatoRequest(
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.TipoContato,
                contato.PessoaId
            );
        }

        public static ContatoResponse ToResponse(this Contato contato)
        {
            return new ContatoResponse(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.TipoContato,
                contato.PessoaId
            );
        }
    }
}