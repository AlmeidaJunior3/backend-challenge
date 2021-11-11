using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Challenge.Domain.Entities
{
    public class PedidoEntity
    {
        [Key]        
        public string Pedido { get; private set; }
        public List<ItemPedidoEntity> Itens { get;  set; }

        public PedidoEntity(string pedido)
        { 
            Pedido = pedido;              
        }
    }
     
}
