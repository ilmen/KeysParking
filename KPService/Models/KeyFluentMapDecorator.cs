using KPLibrary;
using System;
using System.Data.Entity;

namespace KPService.Models
{
    public class KeyFluentMapDecorator
    {
        public void Decorate (DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException();

            modelBuilder.Entity<Key>().ToTable("keys", "public");
            modelBuilder.Entity<Key>().HasKey(k => k.Id);
            modelBuilder.Entity<Key>().Property(p => p.Login).IsRequired();
            modelBuilder.Entity<Key>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<Key>().Property(p => p.SiteLink).HasColumnName("link");
        }
    }
}