namespace EcommerceWeb.Models
{
    public class Produto
    {
        // propriedades
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorFinal => Preco * (1 - Desconto);
    }
}