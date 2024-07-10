using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionPedidos.EN;

public partial class Pedido
{
    [Key]
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fechapedidod { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedido { get; set; } = new List<DetallePedido>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Pedido")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
