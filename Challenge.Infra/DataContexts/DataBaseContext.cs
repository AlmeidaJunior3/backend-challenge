using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Infra.DataContexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        public DbSet<PedidoEntity> Pedidos { get; set; }
        public DbSet<ItemPedidoEntity> ItensPedido { get; set; }
    }
}
