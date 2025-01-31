﻿using SysGestionPedidos.DAL;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionPedidos.BL
{
    internal class PedidoBL
    {
        public async Task<int> CrearAsync(Pedido pPedido)
        {
            return await PedidoDAL.CrearAsync(pPedido);
        }
        public async Task<int> ModificarAsync(Pedido pPedido)
        {
            return await PedidoDAL.ModificarAsync(pPedido);
        }
        public async Task<int> EliminarAsync(Pedido pPedido)
        {
            return await PedidoDAL.EliminarAsync(pPedido);
        }
        public async Task<Pedido> ObtenerPorIdAsync(Pedido pPedido)
        {
            return await PedidoDAL.ObtenerPorIdAsync(pPedido);
        }
        public async Task<List<Pedido>> ObtenerTodosAsync()
        {
            return await PedidoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Pedido>> BuscarAsync(Pedido pPedido)
        {
            return await PedidoDAL.BuscarAsync(pPedido);
        }
    }
}
