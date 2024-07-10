using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionPedidos.EN;

public partial class Producto
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Codigo { get; set; }

    public int? IdCategoria { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioCompra { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Producto")]
    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
