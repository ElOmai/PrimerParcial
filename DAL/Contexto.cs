using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entidades;



namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Entidad> Entidad { get; set; }
        public Contexto() : base("ConStr")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }


}
