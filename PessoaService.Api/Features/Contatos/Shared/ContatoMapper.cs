using pessoa_service.Features.Contatos.AtualizarContato;
using pessoa_service.Features.Contatos.CriarContato;
using pessoa_service.Features.Contatos.ObterContatoPorId;
using pessoa_service.Features.Contatos.ObterContatos;
using pessoa_service.Models;

namespace pessoa_service.Features.Contatos
{
    public static class ContatoMapper
    {

        public static Contato ToEntity(this CriarContatoRequest request)
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

        public static void UpdateEntity(this Contato contato, AtualizarContatoRequest request)
        {
            contato.Nome = request.Nome;
            contato.Email = request.Email;
            contato.Telefone = request.Telefone;
            contato.TipoContato = request.TipoContato;
            contato.PessoaId = request.PessoaId;
            contato.UpdatedAt = DateTime.UtcNow;
        }

        public static CriarContatoResponse ToCriarContatoResponse(this Contato contato)
        {
            return new CriarContatoResponse(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.TipoContato,
                contato.PessoaId
            );
        }

        public static AtualizarContatoResponse ToAtualizarContatoResponse(this Contato contato)
        {
            return new AtualizarContatoResponse(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.TipoContato,
                contato.PessoaId
            );
        }

        public static ObterContatosResponse ToObterContatosResponse(this Contato contato)
        {
            return new ObterContatosResponse(
                contato.Id,
                contato.Nome,
                contato.Email,
                contato.Telefone,
                contato.TipoContato,
                contato.PessoaId
            );
        }

        public static ObterContatoPorIdResponse ToObterContatoPorIdResponse(this Contato contato)
        {
            return new ObterContatoPorIdResponse(
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
