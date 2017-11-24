using Model.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EntityConfigs
{
    internal class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);
            Property(p => p.Senha)
                .IsRequired()
                .HasMaxLength(50);
            Property(p => p.DataCadastro)
                .IsRequired();
            Property(p => p.Ativo)
                .IsRequired();
        }
    }
}