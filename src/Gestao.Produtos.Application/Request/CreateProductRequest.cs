namespace Gestao.Produtos.Application.Request
{
    public class CreateProductRequest
    {
        public required string Nome { get; set; }
        public required int MarcaId { get; set; }
        public required int Tipo { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
