using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionPedidos.EN;

public partial class Categoria
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? Nombre { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaDeRegistro { get; set; }

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
