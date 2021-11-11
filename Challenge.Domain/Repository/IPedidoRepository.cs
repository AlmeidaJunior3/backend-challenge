using Challenge.Domain.Entities;

namespace Challenge.Domain.Repository
{
    public interface IPedidoRepository
    {
        void Salvar(PedidoEntity produto);
        PedidoEntity Buscar(string codigoPedido);
    }
}
