using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;
using Common;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersistenceService
{
    public class KundenverwaltungContext : DbContext
    {
        public KundenverwaltungContext() : base(DatabaseConfig.ConnString)
        {
            // Entwicklung
            Database.SetInitializer(new DropCreateDatabaseAlways<KundenverwaltungContext>());

            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a =>
                a.ManifestModule.Name != "<In Memory Module>" &&
                !a.FullName.StartsWith("mscorlib") &&
                !a.FullName.StartsWith("System") &&
                !a.FullName.StartsWith("Microsoft")).ToList();

            allAssemblies.ForEach(assembly =>
            {
                var types = assembly.GetTypes()
                .Where(t =>
                      t.BaseType != null &&
                      t.BaseType.IsGenericType &&
                      (t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)));
                types.ToList().ForEach(t =>
                {
                    dynamic configurationInstance = Activator.CreateInstance(t);
                    modelBuilder.Configurations.Add(configurationInstance);
                });
            });

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}