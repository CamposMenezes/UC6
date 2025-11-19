namespace CadastroDeUsuario.Models
{
    internal class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public DateOnly DataValidade { get; set; }
    }
}
