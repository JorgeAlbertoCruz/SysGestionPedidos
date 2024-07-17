using Microsoft.EntityFrameworkCore;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionPedidos.DAL
{
    public class PedidoDAL
    {
        public static async Task<int> CrearAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pPedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.Id == pPedido.Id);
                pedido.IdUsuario = pPedido.IdUsuario;
                pedido.Estado = pPedido.Estado;
                pedido.FechaPedido = pPedido.FechaPedido;
                pedido.Total = pPedido.Total;
                bdContexto.Update(pedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Pedido pPedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.Id == pPedido.Id);
                bdContexto.Pedido.Remove(pedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Pedido> ObtenerPorIdAsync(Pedido pPedido)
        {
            var pedido = new Pedido();
            using (var bdContexto = new BDContexto())
            {
                pedido = await bdContexto.Pedido.FirstOrDefaultAsync(s => s.Id == pPedido.Id);
            }
            return pedido;
        }
        public static async Task<List<Pedido>> ObtenerTodosAsync()
        {
            var pedidos = new List<Pedido>();
            using (var bdContexto = new BDContexto())
            {
                pedidos = await bdContexto.Pedido.ToListAsync();
            }
            return pedidos;
        }
        internal static IQueryable<Pedido> QuerySelect(IQueryable<Pedido> pQuery, Pedido pPedido)
        {
            if (pPedido.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pPedido.Id);
            if (pPedido.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pPedido.IdUsuario);
            if (!string.IsNullOrWhiteSpace(pPedido.Estado))
                pQuery = pQuery.Where(s => s.Estado.Contains(pPedido.Estado));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pPedido.FechaPedido.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pPedido.FechaPedido.Year, pPedido.FechaPedido.Month, pPedido.FechaPedido.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaPedido >= fechaInicial && s.FechaPedido <= fechaFinal);
            }
            if (pPedido.Top_Aux > 0)
                pQuery = pQuery.Take(pPedido.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Pedido>> BuscarAsync(Pedido pPedido)
        {
            var pedidos = new List<Pedido>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Pedido.AsQueryable();
                select = QuerySelect(select, pPedido);
                pedidos = await select.ToListAsync();
            }
            return pedidos;
        }
    }
}
