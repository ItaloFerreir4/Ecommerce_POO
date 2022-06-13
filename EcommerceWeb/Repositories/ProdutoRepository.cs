using EcommerceWeb.Models;
using System.Linq;

namespace EcommerceWeb.Repositories
{
    public class ProdutoRepository
    {
        private static List<Produto> produtos = new List<Produto>();

        public List<Produto> Read()
        {
            return produtos;
        }

        public List<Produto> ReadPromocoes()
        {
            var promocoes = produtos
                .Where(p => p.Desconto > 0)
                .OrderByDescending(p => p.ValorFinal);

            return promocoes.ToList();
        }

        public void Create(Produto produto)
        {
            produto.IdProduto = (int)DateTimeOffset.Now.ToUnixTimeMilliseconds();        
            produtos.Add(produto);
        }

        public void Delete(int id)
        {
            var produto = produtos.Single(p => p.IdProduto == id);
            produtos.Remove(produto);
        }

        public Produto Read(int id)
        {
            return produtos.Single(p => p.IdProduto == id);
        }

        public void Update(int id, Produto produto)
        {
            var p = produtos.Single(p => p.IdProduto == id);
            p.Nome = produto.Nome;
            p.Descricao = produto.Descricao;
            p.Preco = produto.Preco;
            p.Desconto = produto.Desconto;
        }
    }
}