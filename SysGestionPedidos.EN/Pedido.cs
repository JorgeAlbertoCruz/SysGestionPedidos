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

    [ForeignKey("IdUsuario")]
    public int? IdUsuario { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fechapedidod { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual List<DetallePedido> DetallePedido { get; set; } 

    public  Usuario? Usuario { get; set; }
}
