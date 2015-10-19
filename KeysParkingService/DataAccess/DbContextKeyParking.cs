using KeysParkingService.Models;
using System.Data.Entity;

namespace KeysParkingService.DataAccess
{
    public class DbContextKeyParking : DbContext
    {
        public DbContextKeyParking() : base(nameOrConnectionString: "MonkeyFist") { }
        
        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyGroup> Groups { get; set; }
    }
}