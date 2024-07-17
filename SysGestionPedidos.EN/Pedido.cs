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
    public DateTime FechaPedido { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [NotMapped]
    public int Top_Aux { get; set; }


    public List<DetallePedido> DetallePedido { get; set; }

    public Usuario? Usuario { get; set; }

}