namespace Gestao.Produtos.Domain.Entities
{
    public class Marca : Entity
    {
        public string Nome { get; set; } = string.Empty;

        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
