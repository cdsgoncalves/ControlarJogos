using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Contexts
{
    public class S2ItContext : DbContext
    {
        public S2ItContext() : base("S2ItContext")
        {
            Configuration.LazyLoadingEnabled = true;
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        /// <summary>
        /// Override do método que cria o modelo no banco de dados para aplicar algumas convenções.
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<S2ItContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }
    }
}