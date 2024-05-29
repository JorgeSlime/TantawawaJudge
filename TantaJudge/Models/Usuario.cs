using System.ComponentModel.DataAnnotations;
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }  // Clave primaria
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string ROL { get; set; } = "Usuario registrado";  // Default role, can be "Admin" or "Usuario registrado"
}

