using Microsoft.EntityFrameworkCore;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionPedidos.DAL
{
    public class DetallePedidoDAL
    {
        public static async Task<int> CrearAsync(DetallePedido pDetallePedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDetallePedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(DetallePedido pDetallePedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detallepedido = await bdContexto.DetallePedido.FirstOrDefaultAsync(s => s.Id == pDetallePedido.Id);
                detallepedido.IdPedido = pDetallePedido.IdPedido;
                detallepedido.IdProducto = pDetallePedido.IdProducto;
                detallepedido.Cantidad = pDetallePedido.Cantidad;
                detallepedido.PrecioUnitario = pDetallePedido.PrecioUnitario;
                bdContexto.Update(detallepedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(DetallePedido pDetallePedido)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detallepedido = await bdContexto.DetallePedido.FirstOrDefaultAsync(s => s.Id == pDetallePedido.Id);
                bdContexto.DetallePedido.Remove(detallepedido);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<DetallePedido> ObtenerPorIdAsync(DetallePedido pDetallePedido)
        {
            var detallepedido = new DetallePedido();
            using (var bdContexto = new BDContexto())
            {
                detallepedido = await bdContexto.DetallePedido.FirstOrDefaultAsync(s => s.Id == pDetallePedido.Id);
            }
            return detallepedido;
        }
        public static async Task<List<DetallePedido>> ObtenerTodosAsync()
        {
            var detallepedidos = new List<DetallePedido>();
            using (var bdContexto = new BDContexto())
            {
                detallepedidos = await bdContexto.DetallePedido.ToListAsync();
            }
            return detallepedidos;
        }
        internal static IQueryable<DetallePedido> QuerySelect(IQueryable<DetallePedido> pQuery, DetallePedido pDetallePedido)
        {
            if (pDetallePedido.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pDetallePedido.Id);
            if (pDetallePedido.IdPedido > 0)
                pQuery = pQuery.Where(s => s.IdPedido == pDetallePedido.IdPedido);
            if (pDetallePedido.IdProducto > 0)
                pQuery = pQuery.Where(s => s.IdProducto == pDetallePedido.IdProducto);
            if (pDetallePedido.Cantidad > 0)
                pQuery = pQuery.Where(s => s.Cantidad == pDetallePedido.Cantidad);
            if (pDetallePedido.PrecioUnitario > 0)
                pQuery = pQuery.Where(s => s.PrecioUnitario == pDetallePedido.PrecioUnitario);
            if (pDetallePedido.Top_Aux > 0)
                pQuery = pQuery.Take(pDetallePedido.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<DetallePedido>> BuscarAsync(DetallePedido pDetallePedido)
        {
            var detallepedidos = new List<DetallePedido>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.DetallePedido.AsQueryable();
                select = QuerySelect(select, pDetallePedido);
                detallepedidos = await select.ToListAsync();
            }
            return detallepedidos;
        }
    }
}
