using Microsoft.EntityFrameworkCore;  //AGREGAR
using WebApiLibros.Models;


namespace WebApiLibros.Data
{
    public class DBLibrosContext : DbContext
    {
        // Este constructor va siempre.
        public DBLibrosContext(DbContextOptions <DBLibrosContext> options) : base(options) { }

        // Propiedades

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
