using KPLibrary;
using System.Data.Entity;

namespace KPService.Models
{
    public sealed class KPDbContext : DbContext
    {
        public KPDbContext()
            : this(new DefaultConnectionStringProvider())
        { }

        public KPDbContext(IConnectionStringProvider connStrProvider)
            : base(connStrProvider.ConnectionString)
        { }

        public string ReadOnlyConnectionString
        {
            get
            {
                return base.Database.Connection.ConnectionString;
            }
        }

        public DbSet<Key> Keys
        { get; set; }

        public DbSet<KeyGroup> KeyGroups
        { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new KeyFluentMapDecorator().Decorate(modelBuilder);
            new KeyGroupFluentMapDecorator().Decorate(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}