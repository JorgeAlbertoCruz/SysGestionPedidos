using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;


namespace SysGestionPedidos.DAL
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<DetallePedido> DetallePedido { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Producto> Producto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=BDGestionPedidos.mssql.somee.com;packet size=4096;user id=SamuelArias_SQLLogin_1;pwd=x1or3ggeiq;data source=BDGestionPedidos.mssql.somee.com;persist security info=False;initial catalog=BDGestionPedidos;TrustServerCertificate=True");
        }
    }
}
