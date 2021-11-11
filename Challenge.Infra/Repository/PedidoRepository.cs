using Challenge.Domain.Entities;
using Challenge.Domain.Repository;
using Challenge.Infra.DataContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Challenge.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private DataBaseContext _contexto;
        public PedidoRepository(DataBaseContext contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(PedidoEntity pedido)
        { 
            _contexto.Pedidos.Add(pedido); 
            _contexto.SaveChanges();
        }

        public PedidoEntity Buscar(string codigoPedido)
        {             
            var pedido = _contexto.Pedidos.Include(m => m.Itens).Where(x => x.Pedido == codigoPedido).FirstOrDefault();
             
            return pedido;
        }
    }
}
