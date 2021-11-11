using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Entities
{
    public class ItemPedidoEntity
    {
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public string Pedido { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Qtd { get; private set; }
        
        public ItemPedidoEntity(string pedido, string descricao,decimal precoUnitario,int qtd)
        {
            Pedido = pedido;
            Descricao = descricao;
            PrecoUnitario = precoUnitario;
            Qtd = qtd;
        }
    }
}
