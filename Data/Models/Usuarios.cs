using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Usuarios
{
    [Key]
    public int UsuarioId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string CorreoElectronico { get; set; } = string.Empty;
    public string Dirrecion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
}