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

    [ForeignKey("IdPedido")]
    public int? IdPedido { get; set; }


    [ForeignKey("IdProducto")]
    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioUnitario { get; set; }

    [NotMapped]
    public int Top_Aux { get; set; }

    public Pedido? Pedido { get; set; }

    public Producto? Producto { get; set; }
}
