using System.Data.Entity;

namespace PersistenceService._1___Implementation
{
    public partial class KundenverwaltungModelContainer : DbContext
    {
         public KundenverwaltungModelContainer(string connectionString) : base(connectionString) { }
    }
}