using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysGestionPedidos.EN;

public partial class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre es obligatorio")]
    [StringLength(255, ErrorMessage = "Maximo 255 caracteres")]
    public string? Nombre { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    [NotMapped]
    public int Top_Aux { get; set; }

    public List<Producto> Producto { get; set; }

}
