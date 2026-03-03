namespace Gestao.Produtos.Application.Request
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Tipo { get; set; }
        public int MarcaId { get; set; }
        public DateTime? DataValidade { get; set; }

    }
}
