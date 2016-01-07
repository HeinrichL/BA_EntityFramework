//using System;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration;
//using System.Linq;
//using System.Threading.Tasks;
//using Common;

//namespace PersistenceService
//{
//    public class KundenverwaltungContext : DbContext
//    {
//        public KundenverwaltungContext() : base(DatabaseConfig.ConnString)
//        {
//            // Entwicklung
//            Database.SetInitializer(new DropCreateDatabaseAlways<KundenverwaltungContext>());
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a =>
//                a.ManifestModule.Name != "<In Memory Module>" &&
//                !a.FullName.StartsWith("mscorlib") &&
//                !a.FullName.StartsWith("System") &&
//                !a.FullName.StartsWith("Microsoft")).ToList();

//            allAssemblies.ForEach(assembly =>
//            {
//                var types = assembly.GetTypes().Where(t =>
//                      t.BaseType != null &&
//                      t.BaseType.IsGenericType &&
//                      (t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>) ||
//                      t.BaseType.GetGenericTypeDefinition() == typeof(ComplexTypeConfiguration<>)));
//                types.ToList().ForEach(t =>
//                {
//                    dynamic configurationInstance = Activator.CreateInstance(t);
//                        modelBuilder.Configurations.Add(configurationInstance);
//                });
//            });

//            base.OnModelCreating(modelBuilder);
//        }
//    }
//}