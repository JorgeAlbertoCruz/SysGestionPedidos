using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionPedidos.EN;

public partial class DetallePedido
{
    [Key]
    public int Id { get; set; }

    public int? IdPedido { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("DetallePedido")]
    public virtual Pedido? IdPedidoNavigation { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("DetallePedido")]
    public virtual Producto? IdProductoNavigation { get; set; }
}
