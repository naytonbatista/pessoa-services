namespace pessoa_service.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }

        public int Idade => DateTime.Today.Year - DataNascimento.Year - (DateTime.Today < DataNascimento.AddYears(DateTime.Today.Year - DataNascimento.Year) ? 1 : 0);
    }
}
