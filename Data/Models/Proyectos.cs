using System.ComponentModel.DataAnnotations;

namespace Data.Models;
public class Proyectos
{
    [Key]
    public int ProyectoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public double Presupuesto { get; set; }
}