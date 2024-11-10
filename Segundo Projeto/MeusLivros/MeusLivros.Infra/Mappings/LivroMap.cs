using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            //Informar o nome da tabela no banco de dados
            builder.ToTable("TbLivro");

            //Especifica qual a chave primaria ta tabela
            builder.HasKey(x => x.Id);

            //espeficicar que o campo é auto incremento
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("LivNome") 
                .HasColumnType("VARCHAR") 
                .HasMaxLength(100)        
                .IsRequired();            

            builder.Property(x => x.Lancamento)
                .HasColumnName("LivLancamento") 
                .HasColumnType("DATETIME")      
                .IsRequired();                 

            builder.Property(x => x.EditoraId)
                .HasColumnName("EditoraId") 
                .IsRequired();                 

            //builder.HasOne(x => x.Editora)         
            //    .WithMany()                        
            //    .HasForeignKey(x => x.EditoraId)   
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
