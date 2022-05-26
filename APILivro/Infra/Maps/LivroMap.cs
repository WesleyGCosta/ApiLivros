using APILivro.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APILivro.Infra.Maps
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Isbn).IsRequired().HasColumnType("varchar(30)");
            builder.Property(l => l.Titulo).IsRequired().HasColumnType("varchar(50)");
            builder.Property(l => l.Edicao).IsRequired().HasColumnType("varchar(50)");
            builder.Property(l => l.AnoEdicao).IsRequired().HasColumnType("int");
            builder.Property(l => l.Paginas).IsRequired().HasColumnType("int");
            builder.Property(l => l.Editor).IsRequired().HasColumnType("varchar(50)");
            builder.Property(l => l.Autor).IsRequired().HasColumnType("varchar(50)");
            builder.Property(l => l.Descricao).IsRequired().HasColumnType("varchar(500)");
        }
    }
}
