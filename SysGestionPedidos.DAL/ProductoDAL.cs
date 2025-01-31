﻿using Microsoft.EntityFrameworkCore;
using SysGestionPedidos.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysGestionPedidos.DAL
{
    public class ProductoDAL
    {
        public static async Task<int> CrearAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProducto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                producto.Codigo = pProducto.Codigo;
                producto.IdCategoria = pProducto.IdCategoria;
                producto.Descripcion = pProducto.Descripcion;
                producto.PrecioCompra = pProducto.PrecioCompra;
                producto.PrecioVenta = pProducto.PrecioVenta;
                producto.Stock = pProducto.Stock;
                bdContexto.Update(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Producto pProducto)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
                bdContexto.Producto.Remove(producto);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Producto> ObtenerPorIdAsync(Producto pProducto)
        {
            var producto = new Producto();
            using (var bdContexto = new BDContexto())
            {
                producto = await bdContexto.Producto.FirstOrDefaultAsync(s => s.Id == pProducto.Id);
            }
            return producto;
        }
        public static async Task<List<Producto>> ObtenerTodosAsync()
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                productos = await bdContexto.Producto.ToListAsync();
            }
            return productos;
        }
        internal static IQueryable<Producto> QuerySelect(IQueryable<Producto> pQuery, Producto pProducto)
        {
            if (pProducto.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProducto.Id);
            if (pProducto.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pProducto.IdCategoria);
            if (!string.IsNullOrWhiteSpace(pProducto.Codigo))
                pQuery = pQuery.Where(s => s.Codigo.Contains(pProducto.Codigo));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pProducto.Descripcion))
                pQuery = pQuery.Where(s => s.Descripcion.Contains(pProducto.Descripcion));
            if (pProducto.PrecioCompra > 0)
                pQuery = pQuery.Where(s => s.PrecioCompra == pProducto.PrecioCompra);
            if (pProducto.PrecioVenta > 0)
                pQuery = pQuery.Where(s => s.PrecioVenta == pProducto.PrecioVenta);
            if (pProducto.Stock >= 0)
                pQuery = pQuery.Where(s => s.Stock == pProducto.Stock);
            if (pProducto.FechaRegistro.Year > 1000)
            {
                DateTime fechaInicial = new DateTime(pProducto.FechaRegistro.Year, pProducto.FechaRegistro.Month, pProducto.FechaRegistro.Day, 0, 0, 0);
                DateTime fechaFinal = fechaInicial.AddDays(1).AddMilliseconds(-1);
                pQuery = pQuery.Where(s => s.FechaRegistro >= fechaInicial && s.FechaRegistro <= fechaFinal);
            }
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pProducto.Top_Aux > 0)
                pQuery = pQuery.Take(pProducto.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Producto>> BuscarAsync(Producto pProducto)
        {
            var productos = new List<Producto>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Producto.AsQueryable();
                select = QuerySelect(select, pProducto);
                productos = await select.ToListAsync();
            }
            return productos;
        }

    }
}
