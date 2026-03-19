using pessoa_service.Enums;

namespace pessoa_service.Models
{
    public sealed class Contato
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public ETipoContato TipoContato { get; set; } = ETipoContato.Outro;
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        #endregion
    }
}