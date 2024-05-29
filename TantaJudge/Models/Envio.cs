using System.ComponentModel.DataAnnotations;
public class Envio
{
    [Key]
    public long EnvioId { get; set; }  // Clave primaria
    public string? NombreDelProblema { get; set; }
    public string? Veredicto { get; set; }  // Puede ser AC, WA, RTE, TLE, CE
    public string? Codigo { get; set; }
    public DateTime FechaDeEnvio { get; set; }
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
    public TipoDeLenguaje Lenguaje { get; set; }
    public int ProblemaId { get; set; }
    public Problema? Problema { get; set; }
}

