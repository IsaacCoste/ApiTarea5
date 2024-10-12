using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;
public class Tareas
{
    [Key]
    public int TareaId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public bool Completada { get; set; }
    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    [ForeignKey("ProyectoId")]
    public int ProyectoId { get; set; }
}