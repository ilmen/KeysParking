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

            modelBuilder.Entity<Key>().Property(p => p.Id).HasColumnName("keyid");
            modelBuilder.Entity<Key>().Property(p => p.GroupId).HasColumnName("groupid");
            modelBuilder.Entity<Key>().Property(p => p.CreateTime).HasColumnName("createtime");
            modelBuilder.Entity<Key>().Property(p => p.Login).IsRequired();
            modelBuilder.Entity<Key>().Property(p => p.Login).HasColumnName("login");
            modelBuilder.Entity<Key>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<Key>().Property(p => p.Password).HasColumnName("password");
            modelBuilder.Entity<Key>().Property(p => p.SiteLink).HasColumnName("link");
        }
    }
}