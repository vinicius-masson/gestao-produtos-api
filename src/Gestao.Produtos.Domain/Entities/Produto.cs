using Gestao.Produtos.Domain.Enums;

namespace Gestao.Produtos.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto(string nome, int marcaId, TipoProdutoEnum tipo, DateTime? dataValidade)
        {
            Nome = nome;
            Tipo = tipo;
            MarcaId = marcaId;
            DataValidade = dataValidade.GetValueOrDefault();
            DataInclusaoRegistro = DateTime.Now;
        }

        internal Produto() { }

        public string Nome { get; private set; } = string.Empty;
        public DateTime? DataValidade { get; private set; }
        public Marca Marca { get; private set; }
        public int MarcaId { get; private set; }
        public TipoProdutoEnum Tipo { get; private set; }
    }
}
