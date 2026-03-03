namespace Gestao.Produtos.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; private set; }

        public DateTime DataInclusaoRegistro { get; set; }
    }
}
