namespace Gestao.Produtos.Application.Response
{
    public class ProductResponse
    {
        public string Nome { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int TipoId { get; set; }
        public int MarcaId { get; set; }
        public string DataValidade { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
