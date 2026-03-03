using AutoMapper;
using Gestao.Produtos.Application.Exceptions;
using Gestao.Produtos.Application.Request;
using Gestao.Produtos.Application.Services;
using Gestao.Produtos.Domain.Entities;
using Gestao.Produtos.Domain.Enums;
using Gestao.Produtos.Domain.Interfaces;
using Moq;

namespace Gestao.Produtos.Tests.Unit.Application
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _mapperMock = new Mock<IMapper>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetProduct_ShouldReturnProductResponse_WhenProductExists()
        {
            // Arrange
            var id = 1;
            var produto = new Produto("Produto Teste", 1, TipoProdutoEnum.Vestuario, DateTime.Now.AddMonths(1));

            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(produto);

            // Act
            var result = await _produtoService.GetProduct(id, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(produto.Nome, result.Nome);
            Assert.Equal(produto.Tipo.ToString(), result.Tipo);
            _produtoRepositoryMock.Verify(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnTrue_WhenProductIsDeleted()
        {
            // Arrange
            var id = 1;
            var produtoExistente = new Produto("Produto Teste", 1, TipoProdutoEnum.Saude, DateTime.Now.AddMonths(1));

            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(produtoExistente);
            _produtoRepositoryMock.Setup(repo => repo.DeleteAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act
            var result = await _produtoService.DeleteProduct(id, CancellationToken.None);

            // Assert
            Assert.True(result);
            _produtoRepositoryMock.Verify(repo => repo.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteProduct_ShouldThrowNotFoundException_WhenProductDoesNotExist()
        {
            // Arrange
            var id = 1;
            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(id, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Produto)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await _produtoService.DeleteProduct(id, CancellationToken.None));
            _produtoRepositoryMock.Verify(repo => repo.DeleteAsync(id, It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
