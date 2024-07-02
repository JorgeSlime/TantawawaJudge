using System.ComponentModel.DataAnnotations;
public class Problema
{
    [Key]
    public int ProblemaId { get; set; }  // Clave primaria
    public string? Titulo { get; set; }
    public string? Tag { get; set; }
    public int Dificultad { get; set; }
    public string? Descripcion { get; set; }
    public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    public string Pdfpro { get; set; }
}

