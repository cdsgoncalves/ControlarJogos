using Model.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EntityConfigs
{
    internal class JogoConfig : EntityTypeConfiguration<Jogo>
    {
        public JogoConfig()
        {
            HasKey(p => p.Id);
            Property(p => p.IdUsuarioAtual)
                .IsRequired();
            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);
            Property(p => p.IdUsuarioAtual)
                .IsRequired();
            Property(p => p.Ativo)
                .IsRequired();
        }
    }
}