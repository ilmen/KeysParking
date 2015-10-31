using KPLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KPService.Models
{
    public class KeyGroupFluentMapDecorator
    {
        public void Decorate (DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException();

            modelBuilder.Entity<KeyGroup>().ToTable("keygroups", "public");
            modelBuilder.Entity<KeyGroup>().HasKey(k => k.Id);

            modelBuilder.Entity<KeyGroup>().Property(p => p.Id).HasColumnName("groupid");
            modelBuilder.Entity<KeyGroup>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<KeyGroup>().Property(p => p.Name).HasColumnName("name");
        }
    }
}