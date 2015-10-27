using System.Data.Entity;

namespace KPService.Models
{
    public sealed class PKDbContext : DbContext
    {
        private static readonly PKDbContext _Instance = new PKDbContext();

        public static PKDbContext Instance
        {
            get
            {
                return _Instance;
            }
        }

        private PKDbContext() : base(nameOrConnectionString: "MonkeyFist")
        {
            //var testingPostgres = new F2F.Testing.NUnit.Npgsql.PostgreSQLFeature("");
        }
        
        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyGroup> KeyGroups { get; set; }
    }
}