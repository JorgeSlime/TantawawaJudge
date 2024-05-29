using Microsoft.EntityFrameworkCore;

//namespace TantaJudge.Contexto
//{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Problema> Problemas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones entre las entidades si es necesario
        }
    }

//}

