using Microsoft.EntityFrameworkCore;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SysGestionPedidos.EN;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Sockets;
namespace SysGestionPedidos.DAL
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }

        public virtual DbSet<DetallePedido> DetallePedido { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }

        public virtual DbSet<Producto> Producto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id = BDGestionPedidos2024.mssql.somee.com; packet size = 4096; user id = Jorge_Cruz_SQLLogin_1; pwd = 4ia1keqwdn; data source = BDGestionPedidos2024.mssql.somee.com; persist security info = False; initial catalog = BDGestionPedidos2024; TrustServerCertificate = True");
        }
    }
}
