using System.ComponentModel.DataAnnotations;
public class Comentario
{
    [Key]
    public int ComentarioId { get; set; }  // Clave primaria
    public string? Texto { get; set; }
    public string? Usuario { get; set; }
    private DateTime Fecha { get; set; }

    // Métodos adicionales pueden ser agregados según sea necesario
}

