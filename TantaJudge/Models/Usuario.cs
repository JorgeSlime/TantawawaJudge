using System.ComponentModel.DataAnnotations;
using TantaJudge.Dto;
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }  // Clave primaria
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public RolEnum Rol { get; set; }
}

