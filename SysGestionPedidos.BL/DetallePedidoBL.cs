using SysGestionPedidos.DAL;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionPedidos.BL
{
    internal class DetallePedidoBL
    {
        public async Task<int> CrearAsync(DetallePedido pDetallePedido)
        {
            return await DetallePedidoDAL.CrearAsync(pDetallePedido);
        }
        public async Task<int> ModificarAsync(DetallePedido pDetallePedido)
        {
            return await DetallePedidoDAL.ModificarAsync(pDetallePedido);
        }
        public async Task<int> EliminarAsync(DetallePedido pDetallePedido)
        {
            return await DetallePedidoDAL.EliminarAsync(pDetallePedido);
        }
        public async Task<DetallePedido> ObtenerPorIdAsync(DetallePedido pDetallePedido)
        {
            return await DetallePedidoDAL.ObtenerPorIdAsync(pDetallePedido);
        }
        public async Task<List<DetallePedido>> ObtenerTodosAsync()
        {
            return await DetallePedidoDAL.ObtenerTodosAsync();
        }
        public async Task<List<DetallePedido>> BuscarAsync(DetallePedido pDetallePedido)
        {
            return await DetallePedidoDAL.BuscarAsync(pDetallePedido);
        }
    }
}
