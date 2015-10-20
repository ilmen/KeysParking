using KeysParkingService.Models;
using System.Data.Entity;

namespace KeysParkingService.DataAccess
{
    public sealed class DbContextKeyParking : DbContext
    {
        private static readonly DbContextKeyParking _Instance = new DbContextKeyParking();

        public static DbContextKeyParking Instance
        {
            get
            {
                return _Instance;
            }
        }

        private DbContextKeyParking() : base(nameOrConnectionString: "MonkeyFist") { }
        
        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyGroup> KeyGroups { get; set; }
    }
}