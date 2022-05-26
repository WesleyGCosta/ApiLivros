using APILivro.Model;
using Microsoft.EntityFrameworkCore;

namespace APILivro.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
