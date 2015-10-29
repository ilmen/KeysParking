using System.Data.Entity;

namespace KPService.Models
{
    public sealed class KPDbContext : DbContext
    {
        private static readonly KPDbContext _Instance = new KPDbContext();

        public static KPDbContext Instance
        {
            get
            {
                return _Instance;
            }
        }

        private KPDbContext() : base(nameOrConnectionString: "MonkeyFist")
        {
            //var testingPostgres = new F2F.Testing.NUnit.Npgsql.PostgreSQLFeature("");
        }
        
        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyGroup> KeyGroups { get; set; }
    }
}